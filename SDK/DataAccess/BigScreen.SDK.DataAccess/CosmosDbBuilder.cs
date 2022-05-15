using BigScreen.SDK.DataAccess.Abstractions;
using BigScreen.SDK.DataAccess.Core;
using Microsoft.Extensions.DependencyInjection;

namespace BigScreen.SDK.DataAccess;

internal class CosmosDbBuilder : ICosmosDbBuilder
{
    private readonly CosmosDbConnector _databaseConnector;
    private readonly IServiceCollection _services;

    public CosmosDbBuilder(string endpoint, string accessKey, string databaseName, IServiceCollection services)
    {
        _services = services;
        _databaseConnector = new CosmosDbConnector(endpoint, accessKey, databaseName);
        _services.AddSingleton<IDatabaseConnector>(_databaseConnector);
    }

    public ICosmosDbBuilder AddDbSet<TDb>() where TDb : BaseDbEntry
    {
        _databaseConnector.CreateContainer<TDb>();
        _services.AddScoped<IDbSet<TDb>, DbSet<TDb>>();
        return this;
    }
}