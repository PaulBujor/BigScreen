using BigScreen.SDK.DataAccess.Abstractions;
using BigScreen.SDK.DataAccess.Core;
using Microsoft.Azure.Cosmos;

namespace BigScreen.SDK.DataAccess;

internal class DbSet<TDb> : IDbSet<TDb> where TDb : BaseDbEntry
{
    private readonly Container _container;

    public DbSet(IDatabaseConnector databaseConnector)
    {
        _container = databaseConnector.GetContainer<TDb>();
    }
}