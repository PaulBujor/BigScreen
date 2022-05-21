using System.Collections;
using BigScreen.SDK.DataAccess.Abstractions;
using BigScreen.SDK.DataAccess.Core;
using BigScreen.SDK.DataAccess.Extensions;
using Microsoft.Azure.Cosmos;

namespace BigScreen.SDK.DataAccess;

internal class DbSet<TDb> : IDbSet<TDb> where TDb : BaseDbEntry
{
    private readonly Container _container;

    public DbSet(IDatabaseConnector databaseConnector)
    {
        _container = databaseConnector.GetContainer<TDb>();
    }

    public IEnumerator<TDb> GetEnumerator()
    {
        return _container.GetItemLinqQueryable<TDb>(true).GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public async Task<TDb> GetAsync(string id, string partitionKey)
    {
        return await _container.ReadItemAsync<TDb>(id, new PartitionKey(partitionKey));
    }

    public async Task<TDb> CreateAsync(TDb tdb)
    {
        tdb.Id = Guid.NewGuid().ToString();
        return await _container.CreateItemAsync(tdb);
    }

    public async Task<TDb> UpdateAsync(TDb tdb)
    {
        TDb existingEntry;
        try
        {
            existingEntry = await GetAsync(tdb.Id!, tdb.GetPartitionKeyValue());
        }
        catch (CosmosException)
        {
            throw new InvalidOperationException(
                $"Update operation unsuccessful: object with ID={tdb.Id} does not exist in Partition={tdb.GetPartitionKeyValue()} \nYou cannot change partition key while updating.");
        }

        if (existingEntry.ETag != tdb.ETag)
            throw new InvalidOperationException(
                $"ETag mismatch when trying to updated object with ID={tdb.Id} in Partition={tdb.GetPartitionKeyValue()}");

        return await _container.UpsertItemAsync(tdb, new PartitionKey(tdb.GetPartitionKeyValue()));
    }

    public async Task DeleteByIdAsync(string id, string partitionKey)
    {
        var tdb = await GetAsync(id, partitionKey);
        await DeleteAsync(tdb);
    }

    public async Task DeleteAsync(TDb tdb)
    {
        await _container.DeleteItemAsync<TDb>(tdb.Id, new PartitionKey(tdb.GetPartitionKeyValue()));
    }
}