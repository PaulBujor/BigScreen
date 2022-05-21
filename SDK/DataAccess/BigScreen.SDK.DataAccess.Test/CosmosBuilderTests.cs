using System;
using System.Threading.Tasks;
using BigScreen.SDK.DataAccess.Abstractions;
using BigScreen.SDK.DataAccess.Extensions;
using BigScreen.SDK.DataAccess.Test.Models.CosmosBuilderTest;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Xunit;

namespace BigScreen.SDK.DataAccess.Test;

[Collection("CosmosDB Data Access Tests")]
public class CosmosBuilderTests : IDisposable
{
    private const string HttpsLocalhost = TestConstants.HttpsLocalhost;

    private const string AccessKey = TestConstants.AccessKey;

    private const string DatabaseName = TestConstants.DatabaseName;
    private Action? _dispose;

    public CosmosBuilderTests()
    {
        _dispose = null;
    }

    public void Dispose()
    {
        _dispose?.Invoke();
    }

    [Fact]
    public void Should_Build_Cosmos_Connector()
    {
        var host = new HostBuilder().ConfigureServices(services =>
        {
            services.AddCosmosDb(HttpsLocalhost, AccessKey, DatabaseName);
        }).Build();

        var serviceProvider = host.Services;

        var connector = serviceProvider.GetService<IDatabaseConnector>();
        Assert.NotNull(connector);
        Assert.Equal(typeof(CosmosDbConnector), connector?.GetType());
        _dispose = () => (connector as CosmosDbConnector)?.Dispose();
    }


    [Fact]
    public async Task Should_Add_One_DbSet()
    {
        var host = new HostBuilder().ConfigureServices(services =>
        {
            services.AddCosmosDb(HttpsLocalhost, AccessKey, DatabaseName)
                .AddDbSet<TestDbEntry>();
        }).Build();

        var serviceProvider = host.Services;

        var dbSet = serviceProvider.GetService<IDbSet<TestDbEntry>>();
        Assert.NotNull(dbSet);
        Assert.Equal(typeof(DbSet<TestDbEntry>), dbSet?.GetType());

        var connector = serviceProvider.GetService<IDatabaseConnector>() as CosmosDbConnector;
        await connector?.DeleteContainerAsync<TestDbEntry>()!;
        _dispose = () => connector.Dispose();
    }

    [Fact]
    public async Task Should_Add_Multiple_DbSets()
    {
        var host = new HostBuilder().ConfigureServices(services =>
        {
            services.AddCosmosDb(HttpsLocalhost, AccessKey, DatabaseName)
                .AddDbSet<TestDbEntry>()
                .AddDbSet<AnotherTestDbEntry>();
        }).Build();

        var serviceProvider = host.Services;

        var dbSet = serviceProvider.GetService<IDbSet<TestDbEntry>>();
        Assert.NotNull(dbSet);
        Assert.Equal(typeof(DbSet<TestDbEntry>), dbSet?.GetType());

        var anotherDbSet = serviceProvider.GetService<IDbSet<AnotherTestDbEntry>>();
        Assert.NotNull(anotherDbSet);
        Assert.Equal(typeof(DbSet<AnotherTestDbEntry>), anotherDbSet?.GetType());

        var connector = serviceProvider.GetService<IDatabaseConnector>() as CosmosDbConnector;
        await connector?.DeleteContainerAsync<TestDbEntry>()!;
        await connector.DeleteContainerAsync<AnotherTestDbEntry>();
        _dispose = () => connector.Dispose();
    }
}