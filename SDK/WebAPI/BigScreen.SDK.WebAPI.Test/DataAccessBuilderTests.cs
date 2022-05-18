using AutoMapper;
using BigScreen.SDK.WebAPI.Core;
using BigScreen.SDK.WebAPI.Extensions;
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
        var host = new HostBuilder().ConfigureServices(services =>
        {
            services.AddDataAccess().Build();
        }).Build();

        var serviceProvider = host.Services;

        var mapper = serviceProvider.GetService<IMapper>();
        Assert.NotNull(mapper);
    }
    
    [Fact]
    public void Should_Add_DataAccessService()
    {
        var host = new HostBuilder().ConfigureServices(services =>
        {
            services.AddDataAccess().Add<TestDto, TestDbEntry>().Build();
        }).Build();

        var serviceProvider = host.Services;

        var dataAccess = serviceProvider.GetService<IDataAccess<TestDto>>();
        Assert.NotNull(dataAccess);
        Assert.Equal(typeof(DataAccess<TestDto,TestDbEntry>), dataAccess?.GetType());
    }
    
    [Fact]
    public void Should_Add_Multiple_DataAccessServices()
    {
        var host = new HostBuilder().ConfigureServices(services =>
        {
            services.AddDataAccess().Add<TestDto, TestDbEntry>().Add<TestDto2,TestDbEntry2>().Build();
        }).Build();

        var serviceProvider = host.Services;

        var dataAccess = serviceProvider.GetService<IDataAccess<TestDto>>();
        Assert.NotNull(dataAccess);
        Assert.Equal(typeof(DataAccess<TestDto,TestDbEntry>), dataAccess?.GetType());

        var anotherDataAccess = serviceProvider.GetService<IDataAccess<TestDto2>>();
        Assert.NotNull(anotherDataAccess);
        Assert.Equal(typeof(DataAccess<TestDto2,TestDbEntry2>), anotherDataAccess?.GetType());
    }
}