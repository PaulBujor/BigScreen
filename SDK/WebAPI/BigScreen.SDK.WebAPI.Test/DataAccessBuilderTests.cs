using System.Threading.Tasks;
using AutoMapper;
using BigScreen.SDK.DataAccess;
using BigScreen.SDK.DataAccess.Abstractions;
using BigScreen.SDK.WebAPI.Abstractions;
using BigScreen.SDK.WebAPI.Extensions;
using BigScreen.SDK.WebAPI.Test.Extensions;
using BigScreen.SDK.WebAPI.Test.Models.DataAccessBuilderTest;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Xunit;

namespace BigScreen.SDK.WebAPI.Test;

public class DataAccessBuilderTests
{
    [Fact]
    public void Should_Add_IDataAccessBuilder()
    {
        var host = new HostBuilder().ConfigureServices(services => { services.AddDataAccess().Build(); }).Build();

        var serviceProvider = host.Services;

        var mapper = serviceProvider.GetService<IMapper>();
        Assert.NotNull(mapper);
    }

    [Fact]
    public async Task Should_Add_One_DataAccessService()
    {
        var host = new HostBuilder().ConfigureServices(services =>
        {
            services.AddLocalCosmosDb().AddDbSet<TestDbEntry>();
            services.AddDataAccess().Add<TestDto, TestDbEntry>().Build();
        }).Build();

        var serviceProvider = host.Services;

        var dataAccess = serviceProvider.GetService<IDataAccess<TestDto>>();
        Assert.NotNull(dataAccess);
        Assert.Equal(typeof(DataAccess<TestDto, TestDbEntry>), dataAccess?.GetType());

        var connector = serviceProvider.GetService<IDatabaseConnector>() as CosmosDbConnector;
        await connector?.DeleteContainerAsync<TestDbEntry>()!;
    }

    [Fact]
    public async Task Should_Add_Multiple_DataAccessServices()
    {
        var host = new HostBuilder().ConfigureServices(services =>
        {
            services.AddLocalCosmosDb().AddDbSet<TestDbEntry>().AddDbSet<TestDbEntry2>();
            services.AddDataAccess().Add<TestDto, TestDbEntry>().Add<TestDto2, TestDbEntry2>().Build();
        }).Build();

        var serviceProvider = host.Services;

        var dataAccess = serviceProvider.GetService<IDataAccess<TestDto>>();
        Assert.NotNull(dataAccess);
        Assert.Equal(typeof(DataAccess<TestDto, TestDbEntry>), dataAccess?.GetType());

        var anotherDataAccess = serviceProvider.GetService<IDataAccess<TestDto2>>();
        Assert.NotNull(anotherDataAccess);
        Assert.Equal(typeof(DataAccess<TestDto2, TestDbEntry2>), anotherDataAccess?.GetType());

        var connector = serviceProvider.GetService<IDatabaseConnector>() as CosmosDbConnector;
        await connector?.DeleteContainerAsync<TestDbEntry>()!;
        await connector.DeleteContainerAsync<TestDbEntry2>();
    }
}