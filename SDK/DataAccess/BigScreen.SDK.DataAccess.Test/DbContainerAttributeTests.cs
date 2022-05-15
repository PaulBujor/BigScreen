using System;
using System.Threading.Tasks;
using BigScreen.SDK.DataAccess.Abstractions;
using BigScreen.SDK.DataAccess.Extensions;
using BigScreen.SDK.DataAccess.Test.Models.DbContainerAttributeTest;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Xunit;

namespace BigScreen.SDK.DataAccess.Test;

public class DbContainerAttributeTests
{
    private const string HttpsLocalhost = TestConstants.HttpsLocalhost;

    private const string AccessKey = TestConstants.AccessKey;

    private const string DatabaseName = TestConstants.DatabaseName;

    [Fact]
    public async Task Should_Create_Container_With_Specified_Name()
    {
        var host = new HostBuilder().ConfigureServices(services =>
        {
            services.AddCosmosDb(HttpsLocalhost, AccessKey, DatabaseName)
                .AddDbSet<CorrectDbEntry>();
        }).Build();

        var serviceProvider = host.Services;

        var dbConnector = serviceProvider.GetService<IDatabaseConnector>();
        var container = dbConnector?.GetContainer<CorrectDbEntry>();
        Assert.Equal("Correct", container?.Id);
        //would be nice to test partition but can't find how

        var connector = dbConnector as CosmosDbConnector;
        await connector?.DeleteContainerAsync<CorrectDbEntry>()!;
    }


    [Fact]
    public async Task Should_Create_Container_With_Class_Name()
    {
        var host = new HostBuilder().ConfigureServices(services =>
        {
            services.AddCosmosDb(HttpsLocalhost, AccessKey, DatabaseName)
                .AddDbSet<UnnamedDbEntry>();
        }).Build();

        var serviceProvider = host.Services;

        var dbConnector = serviceProvider.GetService<IDatabaseConnector>();
        var container = dbConnector?.GetContainer<UnnamedDbEntry>();
        Assert.Equal(nameof(UnnamedDbEntry), container?.Id);

        var connector = dbConnector as CosmosDbConnector;
        await connector?.DeleteContainerAsync<UnnamedDbEntry>()!;
    }

    [Fact]
    public void Should_Not_Create_Named_Container_Without_Partition()
    {
        new HostBuilder().ConfigureServices(services =>
        {
            try
            {
                services.AddCosmosDb(HttpsLocalhost, AccessKey, DatabaseName)
                    .AddDbSet<IncorrectDbEntryWithName>();
            }
            catch (AggregateException ex)
            {
                Assert.Equal(typeof(InvalidOperationException), ex.InnerException?.GetType());
            }
        }).Build();
    }

    [Fact]
    public void Should_Not_Create_Unnamed_Container_Without_Partition()
    {
        new HostBuilder().ConfigureServices(services =>
        {
            try
            {
                services.AddCosmosDb(HttpsLocalhost, AccessKey, DatabaseName)
                    .AddDbSet<IncorrectDbEntryWithoutName>();
            }
            catch (AggregateException ex)
            {
                Assert.Equal(typeof(InvalidOperationException), ex.InnerException?.GetType());
            }
        }).Build();
    }

    [Fact]
    public void Should_Not_create_Container_Without_Attribute()
    {
        new HostBuilder().ConfigureServices(services =>
        {
            try
            {
                services.AddCosmosDb(HttpsLocalhost, AccessKey, DatabaseName)
                    .AddDbSet<IncorrectDbEntryWithoutAttribute>();
            }
            catch (AggregateException ex)
            {
                Assert.Equal(typeof(InvalidOperationException), ex.InnerException?.GetType());
            }
        }).Build();
    }
}