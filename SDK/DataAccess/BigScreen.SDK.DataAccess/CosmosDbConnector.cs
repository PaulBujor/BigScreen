using BigScreen.SDK.DataAccess.Abstractions;
using BigScreen.SDK.DataAccess.Core;
using BigScreen.SDK.DataAccess.Extensions;
using Microsoft.Azure.Cosmos;

namespace BigScreen.SDK.DataAccess;

internal class CosmosDbConnector : IDatabaseConnector
{
    private readonly Database _database;

    internal CosmosDbConnector(string endpoint, string accessKey, string databaseName)
    {
        var cosmosClient = new CosmosClient(endpoint, accessKey);
        _database = cosmosClient.CreateDatabaseIfNotExistsAsync(databaseName).Result;
    }

    public Container GetContainer<TDb>() where TDb : BaseDbEntry
    {
        var containerId = typeof(TDb).GetContainerId();
        return _database.GetContainer(containerId);
    }

    internal ContainerResponse CreateContainer<TDb>() where TDb : BaseDbEntry
    {
        return CreateContainerAsync<TDb>().Result;
    }

    private async Task<ContainerResponse> CreateContainerAsync<TDb>() where TDb : BaseDbEntry
    {
        var containerId = typeof(TDb).GetContainerId();
        var containerPartitionKey = typeof(TDb).GetPartitionKeyDefinition();

        //todo validate if partition key actually exists in model

        return await _database.CreateContainerIfNotExistsAsync(new ContainerProperties
        {
            Id = containerId,
            PartitionKeyPath = containerPartitionKey
        });
    }

    internal async Task DeleteContainerAsync<TDb>() where TDb : BaseDbEntry
    {
        await _database.GetContainer(typeof(TDb).GetContainerId()).DeleteContainerAsync();
    }
}