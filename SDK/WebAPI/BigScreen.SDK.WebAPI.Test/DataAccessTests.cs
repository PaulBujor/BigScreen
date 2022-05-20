using System;
using System.Linq;
using System.Threading.Tasks;
using BigScreen.SDK.DataAccess;
using BigScreen.SDK.DataAccess.Abstractions;
using BigScreen.SDK.WebAPI.Abstractions;
using BigScreen.SDK.WebAPI.Extensions;
using BigScreen.SDK.WebAPI.Test.Extensions;
using BigScreen.SDK.WebAPI.Test.Models.DataAccessBuilderTest;
using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Xunit;

namespace BigScreen.SDK.WebAPI.Test;

public class DataAccessTests : IDisposable
{
    private readonly CosmosDbConnector? _cosmosDbConnector;
    private readonly IDataAccess<TestDto>? _dataAccess;

    public DataAccessTests()
    {
        var host = new HostBuilder().ConfigureServices(services =>
        {
            services.AddLocalCosmosDb().AddDbSet<TestDbEntry>();
            services.AddDataAccess().Add<TestDto, TestDbEntry>().Build();
        }).Build();

        var serviceProvider = host.Services;

        _dataAccess = serviceProvider.GetService<IDataAccess<TestDto>>();
        _cosmosDbConnector = serviceProvider.GetService<IDatabaseConnector>() as CosmosDbConnector;
    }

    public void Dispose()
    {
        _cosmosDbConnector?.DeleteContainerAsync<TestDbEntry>();
    }

    [Fact]
    public async Task Should_Add_Item()
    {
        var testDtoObj = new TestDto
        {
            Test = "Walnuts"
        };
        var item = await _dataAccess?.CreateAsync(testDtoObj)!;
        Assert.NotNull(item);
        Assert.Equal(item.Test, testDtoObj.Test);
        Assert.NotNull(item.Id!);
        Assert.NotNull(item.ETag!);
    }

    [Fact]
    public async Task Should_Add_Multiple_Items()
    {
        var testDtoObj1 = new TestDto
        {
            Test = "Walnuts"
        };
        var testDtoObj2 = new TestDto
        {
            Test = "Cashews"
        };
        var testDtoObj3 = new TestDto
        {
            Test = "Peanuts"
        };

        var item1 = await _dataAccess?.CreateAsync(testDtoObj1)!;
        Assert.NotNull(item1);
        Assert.Equal(item1.Test, testDtoObj1.Test);
        Assert.NotNull(item1.Id!);
        Assert.NotNull(item1.ETag!);

        var item2 = await _dataAccess?.CreateAsync(testDtoObj2)!;
        Assert.NotNull(item2);
        Assert.Equal(item2.Test, testDtoObj2.Test);
        Assert.NotNull(item2.Id!);
        Assert.NotNull(item2.ETag!);

        var item3 = await _dataAccess?.CreateAsync(testDtoObj3)!;
        Assert.NotNull(item3);
        Assert.Equal(item3.Test, testDtoObj3.Test);
        Assert.NotNull(item3.Id!);
        Assert.NotNull(item3.ETag!);
    }

    [Fact]
    public async Task Should_Get_Item()
    {
        var testDtoObj = new TestDto
        {
            Test = "Walnuts",
            Test2 = "Comma",
            Test3 = "Alligator"
        };

        var testDtoObj2 = new TestDto
        {
            Test = "Walnuts",
            Test2 = "Deez",
            Test3 = "Sunrise"
        };

        var testDtoObj3 = new TestDto
        {
            Test = "Peanuts"
        };

        var testDto = await _dataAccess?.CreateAsync(testDtoObj)!;
        await _dataAccess?.CreateAsync(testDtoObj2)!;
        await _dataAccess?.CreateAsync(testDtoObj3)!;

        var item = await _dataAccess?.GetAsync(testDto.Id!, testDto.Test!)!;
        Assert.Equal(item.Test, testDtoObj.Test);
        Assert.Equal(item.Test2, testDtoObj.Test2);
        Assert.Equal(item.Test3, testDtoObj.Test3);
        Assert.Equal(testDto.Id, item.Id);
        Assert.Equal(testDto.ETag, item.ETag);
    }

    [Fact]
    public async Task Should_Get_Multiple_Items()
    {
        var testDtoObj = new TestDto
        {
            Test = "Walnuts",
            Test2 = "Comma",
            Test3 = "Alligator"
        };

        var testDtoObj2 = new TestDto
        {
            Test = "Walnuts",
            Test2 = "Deez",
            Test3 = "Sunrise"
        };

        var testDtoObj3 = new TestDto
        {
            Test = "Walnuts",
            Test2 = "Dog",
            Test3 = "Moon"
        };

        var testDtoObj4 = new TestDto
        {
            Test = "Peanuts",
            Test2 = "Dog",
            Test3 = "Moon"
        };

        var testDto = await _dataAccess?.CreateAsync(testDtoObj)!;
        var testDto2 = await _dataAccess?.CreateAsync(testDtoObj2)!;
        var testDto3 = await _dataAccess?.CreateAsync(testDtoObj3)!;
        var testDto4 = await _dataAccess?.CreateAsync(testDtoObj4)!;

        var itemList = await _dataAccess?.GetAllAsync()!;
        Assert.NotNull(itemList);
        Assert.Equal(4, itemList.Count());

        var testItem1 = itemList.FirstOrDefault(v => v.Id == testDto.Id);
        Assert.Equal(testDto.Test, testItem1!.Test);
        Assert.Equal(testDto.Test2, testItem1.Test2);
        Assert.Equal(testDto.Test3, testItem1.Test3);
        Assert.Equal(testDto.ETag, testItem1.ETag);

        var testItem2 = itemList.FirstOrDefault(v => v.Id == testDto2.Id);
        Assert.Equal(testDto2.Test, testItem2!.Test);
        Assert.Equal(testDto2.Test2, testItem2.Test2);
        Assert.Equal(testDto2.Test3, testItem2.Test3);
        Assert.Equal(testDto2.ETag, testItem2.ETag);

        var testItem3 = itemList.FirstOrDefault(v => v.Id == testDto3.Id);
        Assert.Equal(testDto3.Test, testItem3!.Test);
        Assert.Equal(testDto3.Test2, testItem3.Test2);
        Assert.Equal(testDto3.Test3, testItem3.Test3);
        Assert.Equal(testDto3.ETag, testItem3.ETag);

        var testItem4 = itemList.FirstOrDefault(v => v.Id == testDto4.Id);
        Assert.Equal(testDto4.Test, testItem4!.Test);
        Assert.Equal(testDto4.Test2, testItem4.Test2);
        Assert.Equal(testDto4.Test3, testItem4.Test3);
        Assert.Equal(testDto4.ETag, testItem4.ETag);
    }

    [Fact]
    public async Task Should_Get_Multiple_Items_From_Partition()
    {
        var testDtoObj = new TestDto
        {
            Test = "Walnuts",
            Test2 = "Comma",
            Test3 = "Alligator"
        };

        var testDtoObj2 = new TestDto
        {
            Test = "Walnuts",
            Test2 = "Deez",
            Test3 = "Sunrise"
        };

        var testDtoObj3 = new TestDto
        {
            Test = "Walnuts",
            Test2 = "Dog",
            Test3 = "Moon"
        };

        var testDtoObj4 = new TestDto
        {
            Test = "Peanuts",
            Test2 = "Dog",
            Test3 = "Moon"
        };

        var testDto = await _dataAccess?.CreateAsync(testDtoObj)!;
        var testDto2 = await _dataAccess?.CreateAsync(testDtoObj2)!;
        var testDto3 = await _dataAccess?.CreateAsync(testDtoObj3)!;
        var testDto4 = await _dataAccess?.CreateAsync(testDtoObj4)!;

        var itemList = await _dataAccess?.GetAllAsync("Walnuts")!;
        Assert.NotNull(itemList);
        Assert.Equal(3, itemList.Count());

        var testItem1 = itemList.FirstOrDefault(v => v.Id == testDto.Id);
        Assert.Equal(testDto.Test, testItem1!.Test);
        Assert.Equal(testDto.Test2, testItem1.Test2);
        Assert.Equal(testDto.Test3, testItem1.Test3);
        Assert.Equal(testDto.ETag, testItem1.ETag);

        var testItem2 = itemList.FirstOrDefault(v => v.Id == testDto2.Id);
        Assert.Equal(testDto2.Test, testItem2!.Test);
        Assert.Equal(testDto2.Test2, testItem2.Test2);
        Assert.Equal(testDto2.Test3, testItem2.Test3);
        Assert.Equal(testDto2.ETag, testItem2.ETag);

        var testItem3 = itemList.FirstOrDefault(v => v.Id == testDto3.Id);
        Assert.Equal(testDto3.Test, testItem3!.Test);
        Assert.Equal(testDto3.Test2, testItem3.Test2);
        Assert.Equal(testDto3.Test3, testItem3.Test3);
        Assert.Equal(testDto3.ETag, testItem3.ETag);

        var testItem4 = itemList.FirstOrDefault(v => v.Id == testDto4.Id);
        Assert.Null(testItem4);
    }

    [Fact]
    public async Task Should_Patch_Item()
    {
        var testDtoObj = new TestDto
        {
            Test = "Walnuts",
            Test2 = "Comma",
            Test3 = "Alligator"
        };

        var testDto = await _dataAccess?.CreateAsync(testDtoObj)!;

        testDto.Test = "Walnuts";
        testDto.Test2 = "Dot";
        testDto.Test3 = "Cat";

        var item = await _dataAccess.UpdateAsync(testDto);
        Assert.NotNull(item);
        Assert.Equal(testDto.Test2, item.Test2);
        Assert.Equal(testDto.Test3, item.Test3);
    }

    [Fact]
    public async Task Should_Not_Patch_Item_If_ETag_Different()
    {
        var testDtoObj = new TestDto
        {
            Test = "Walnuts",
            Test2 = "Comma",
            Test3 = "Alligator"
        };

        var testDto = await _dataAccess?.CreateAsync(testDtoObj)!;

        testDto.Test = "Walnuts";
        testDto.Test2 = "Dot";
        testDto.ETag = "Cat";

        var updateAct = async () => await _dataAccess.UpdateAsync(testDto);
        await Assert.ThrowsAsync<InvalidOperationException>(updateAct);
    }


    [Fact]
    public async Task Should_Delete_Item_By_Id()
    {
        var testDtoObj = new TestDto
        {
            Test = "Walnuts",
            Test2 = "Comma",
            Test3 = "Alligator"
        };

        var testDto = await _dataAccess?.CreateAsync(testDtoObj)!;

        await _dataAccess.DeleteByIdAsync(testDto.Id!, testDto.Test!);

        var getAct = async () => await _dataAccess?.GetAsync(testDto.Id!, testDto.Test!)!;
        await Assert.ThrowsAsync<CosmosException>(getAct);
    }

    [Fact]
    public async Task Should_Delete_Item_By_Object()
    {
        var testDtoObj = new TestDto
        {
            Test = "Walnuts",
            Test2 = "Comma",
            Test3 = "Alligator"
        };

        var testDto = await _dataAccess?.CreateAsync(testDtoObj)!;

        await _dataAccess.DeleteAsync(testDto);

        var getAct = (Func<Task<TestDto>>) (async () => await _dataAccess?.GetAsync(testDto.Id!, testDto.Test!)!);
        await Assert.ThrowsAsync<CosmosException>(getAct);
    }
}