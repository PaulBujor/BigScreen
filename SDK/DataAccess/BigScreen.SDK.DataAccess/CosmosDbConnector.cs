using System.Reflection;
using BigScreen.SDK.DataAccess.Abstractions;
using BigScreen.SDK.DataAccess.Attributes;
using BigScreen.SDK.DataAccess.Core;
using BigScreen.SDK.DataAccess.Helpers;
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
        var containerId = CosmosDbConnectorHelper.GetContainerId<TDb>();
        return _database.GetContainer(containerId);
    }

    internal ContainerResponse CreateContainer<TDb>() where TDb : BaseDbEntry
    {
        return CreateContainerAsync<TDb>().Result;
    }

    private async Task<ContainerResponse> CreateContainerAsync<TDb>() where TDb : BaseDbEntry
    {
        var dbContainerAttribute = typeof(TDb).GetCustomAttribute<DbContainerAttribute>();

        if (dbContainerAttribute == null)
            throw new InvalidOperationException(
                $"{typeof(TDb).FullName} is missing the DbContainer attribute!");

        var containerId = CosmosDbConnectorHelper.GetContainerId<TDb>();

        if (string.IsNullOrWhiteSpace(dbContainerAttribute.PartitionKey))
            throw new InvalidOperationException(
                $"{typeof(TDb).FullName} does not have a Partition Key set in the DbContainer attribute!");
        var containerPartitionKey = dbContainerAttribute.PartitionKey;

        if (containerPartitionKey[0] != '/') containerPartitionKey = $"/{containerPartitionKey}";

        //todo validate if partition key actually exists in model

        return await _database.CreateContainerIfNotExistsAsync(new ContainerProperties
        {
            Id = containerId,
            PartitionKeyPath = containerPartitionKey
        });
    }

    internal async Task DeleteContainerAsync<TDb>() where TDb : BaseDbEntry
    {
        await _database.GetContainer(CosmosDbConnectorHelper.GetContainerId<TDb>()).DeleteContainerAsync();
    }
}