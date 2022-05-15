using BigScreen.SDK.DataAccess.Abstractions;
using BigScreen.SDK.DataAccess.Core;
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
        return _database.GetContainer(nameof(TDb));
    }

    internal ContainerResponse CreateContainer<TDb>() where TDb : BaseDbEntry
    {
        return CreateContainerAsync<TDb>().Result;
    }

    internal async Task<ContainerResponse> CreateContainerAsync<TDb>() where TDb : BaseDbEntry
    {
        //todo validate if it has DbContainerAttribute
        return await _database.CreateContainerIfNotExistsAsync(new ContainerProperties
        {
            Id = typeof(TDb).Name,
            PartitionKeyPath = "/StaticPartition" //todo take from DbContainerAttribute
        });
    }

    internal async Task DeleteContainerAsync<TDb>() where TDb : BaseDbEntry
    {
        await _database.GetContainer(typeof(TDb).Name).DeleteContainerAsync();
    }
}