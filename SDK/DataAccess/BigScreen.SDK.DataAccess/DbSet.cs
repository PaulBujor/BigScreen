using System.Collections;
using BigScreen.SDK.DataAccess.Abstractions;
using BigScreen.SDK.DataAccess.Core;
using BigScreen.SDK.DataAccess.Exceptions;
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

    public async Task<TDb> GetAsync(string key)
    {
        try
        {
            var existingEntry = this.FirstOrDefault(entry => entry.Id == key);
            if (existingEntry == null) throw new ItemNotFoundException(key);

            return await Task.FromResult(existingEntry);
        }
        catch (CosmosException ce)
        {
            throw new ItemNotFoundException(key);
        }
    }

    public async Task<TDb> CreateAsync(TDb tdb)
    {
        tdb.Id = Guid.NewGuid().ToString();
        return await _container.CreateItemAsync(tdb);
    }

    public async Task<TDb> UpdateAsync(TDb tdb)
    {
        if (tdb.Id == null) throw new InvalidModelException(nameof(tdb.Id));

        var existingEntry = await GetAsync(tdb.Id);
        if (existingEntry.GetPartitionKeyValue() != tdb.GetPartitionKeyValue())
            throw new PartitionMismatchException(tdb.Id, tdb.GetPartitionKeyValue());

        if (existingEntry.ETag != tdb.ETag) throw new ETagMismatchException(tdb.Id, tdb.ETag!);

        try
        {
            return await _container.UpsertItemAsync(tdb, new PartitionKey(tdb.GetPartitionKeyValue()));
        }
        catch (CosmosException ce)
        {
            throw new UpdateFailedException(tdb.Id, ce);
        }
    }

    public async Task DeleteAsync(string key)
    {
        var existingEntry = await GetAsync(key);
        await _container.DeleteItemAsync<TDb>(existingEntry.Id, new PartitionKey(existingEntry.GetPartitionKeyValue()));
    }
}