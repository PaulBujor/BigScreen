using System;
using System.Linq;
using System.Threading.Tasks;
using BigScreen.SDK.DataAccess.Abstractions;
using BigScreen.SDK.DataAccess.Exceptions;
using BigScreen.SDK.DataAccess.Extensions;
using BigScreen.SDK.DataAccess.Test.Models.DbSetTest;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Xunit;

namespace BigScreen.SDK.DataAccess.Test;

[Collection("CosmosDB Data Access Tests")]
public class DbSetTests : IDisposable
{
    private readonly CosmosDbConnector? _connector;
    private readonly IDbSet<TestPersonDbEntry> _dbSet;

    public DbSetTests()
    {
        var builder = new HostBuilder().ConfigureServices(services =>
        {
            services.AddCosmosDb(TestConstants.HttpsLocalhost, TestConstants.AccessKey, TestConstants.DatabaseName)
                .AddDbSet<TestPersonDbEntry>();
        }).Build();

        _connector = builder.Services.GetService<IDatabaseConnector>() as CosmosDbConnector;
        _dbSet = builder.Services.GetService<IDbSet<TestPersonDbEntry>>()!;
    }

    public void Dispose()
    {
        _connector?.DeleteContainerAsync<TestPersonDbEntry>().Wait();
        _connector?.Dispose();
    }

    [Fact]
    public async Task Should_Create()
    {
        var person = new TestPersonDbEntry
        {
            FirstName = "Johnny",
            LastName = "You know who"
        };

        var result = await _dbSet.CreateAsync(person);

        Assert.Equal(person.FirstName, result.FirstName);
        Assert.Equal(person.LastName, result.LastName);
        Assert.Equal(person.Id, result.Id);
        Assert.NotNull(result.ETag);
    }

    [Fact]
    public async Task Should_Read_One()
    {
        var person = new TestPersonDbEntry
        {
            FirstName = "Johnny",
            LastName = "You know who"
        };

        await _dbSet.CreateAsync(person);
        var read = await _dbSet.GetAsync(person.Id!);

        Assert.Equal(person.FirstName, read.FirstName);
        Assert.Equal(person.LastName, read.LastName);
        Assert.Equal(person.Id, read.Id);
        Assert.NotNull(read.ETag);
    }

    [Fact]
    public async Task Should_Read_One_Through_Query()
    {
        var person = new TestPersonDbEntry
        {
            FirstName = "Johnny",
            LastName = "You know who"
        };

        await _dbSet.CreateAsync(person);
        var read = _dbSet.FirstOrDefault(entry => entry.Id == person.Id)!;

        Assert.Equal(person.FirstName, read.FirstName);
        Assert.Equal(person.LastName, read.LastName);
        Assert.Equal(person.Id, read.Id);
        Assert.NotNull(read.ETag);
    }

    [Fact]
    public async Task Should_Read_Many()
    {
        var person1 = new TestPersonDbEntry
        {
            FirstName = "Johnny",
            LastName = "You know who"
        };
        var person2 = new TestPersonDbEntry
        {
            FirstName = "Joana",
            LastName = "You know who"
        };
        var person3 = new TestPersonDbEntry
        {
            FirstName = "Mary",
            LastName = "Bloody"
        };

        await _dbSet.CreateAsync(person1);
        await _dbSet.CreateAsync(person2);
        await _dbSet.CreateAsync(person3);
        var read = _dbSet.ToList();

        Assert.NotEmpty(read);
        Assert.Equal(3, read.Count);
    }

    [Fact]
    public async Task Should_Filter()
    {
        var person1 = new TestPersonDbEntry
        {
            FirstName = "Johnny",
            LastName = "You know who"
        };
        var person2 = new TestPersonDbEntry
        {
            FirstName = "Joana",
            LastName = "You know who"
        };
        var person3 = new TestPersonDbEntry
        {
            FirstName = "Mary",
            LastName = "Bloody"
        };

        await _dbSet.CreateAsync(person1);
        await _dbSet.CreateAsync(person2);
        await _dbSet.CreateAsync(person3);
        var read = _dbSet.Where(entry => entry.LastName == person1.LastName).ToList();

        Assert.NotEmpty(read);
        Assert.Equal(2, read.Count);
        Assert.Contains(person1, read);
        Assert.Contains(person2, read);
    }

    [Fact]
    public async Task Should_Order_By()
    {
        var person1 = new TestPersonDbEntry
        {
            FirstName = "BJohnny",
            LastName = "You know who"
        };
        var person2 = new TestPersonDbEntry
        {
            FirstName = "AJoana",
            LastName = "You know who"
        };
        var person3 = new TestPersonDbEntry
        {
            FirstName = "CMary",
            LastName = "Bloody"
        };

        await _dbSet.CreateAsync(person1);
        await _dbSet.CreateAsync(person2);
        await _dbSet.CreateAsync(person3);
        var read = _dbSet.OrderBy(entry => entry.FirstName).ToList();

        Assert.NotEmpty(read);
        Assert.Equal(3, read.Count);
        Assert.Equal(person2, read[0]);
        Assert.Equal(person1, read[1]);
        Assert.Equal(person3, read[2]);
    }

    [Fact]
    public async Task Should_Select()
    {
        var person1 = new TestPersonDbEntry
        {
            FirstName = "Johnny",
            LastName = "You know who"
        };
        var person2 = new TestPersonDbEntry
        {
            FirstName = "Joana",
            LastName = "You know who"
        };
        var person3 = new TestPersonDbEntry
        {
            FirstName = "Mary",
            LastName = "Bloody"
        };

        await _dbSet.CreateAsync(person1);
        await _dbSet.CreateAsync(person2);
        await _dbSet.CreateAsync(person3);
        var read = _dbSet.Select(entry => entry.FirstName).ToList();

        Assert.NotEmpty(read);
        Assert.Equal(3, read.Count);
        Assert.Equal(person1.FirstName, read[0]);
        Assert.Equal(person2.FirstName, read[1]);
        Assert.Equal(person3.FirstName, read[2]);
    }

    [Fact]
    public async Task Should_Update()
    {
        var person = new TestPersonDbEntry
        {
            FirstName = "Johnny",
            LastName = "You know who"
        };

        var result = await _dbSet.CreateAsync(person);

        result.FirstName = "Mary";

        var update = await _dbSet.UpdateAsync(result);
        Assert.Equal(result.FirstName, update.FirstName);
        Assert.Equal(result.LastName, update.LastName);
        Assert.Equal(result.Id, update.Id);
        Assert.NotEqual(result.ETag, update.ETag);

        //check that data is not duplicated - a second entry would be lower in the database and therefore not retrieved first by GetAsync
        var readAgain = await _dbSet.GetAsync(person.Id!);
        Assert.Equal(update.FirstName, readAgain.FirstName);
        Assert.Equal(update.LastName, readAgain.LastName);
        Assert.Equal(update.Id, readAgain.Id);
        Assert.Equal(update.ETag, readAgain.ETag);
    }

    [Fact]
    public async Task Should_Not_Update_If_Partition_Key_Changed()
    {
        var person = new TestPersonDbEntry
        {
            FirstName = "Johnny",
            LastName = "You know who"
        };

        var result = await _dbSet.CreateAsync(person);

        result.FirstName = "Mary";
        result.LastName = "You know what";

        await Assert.ThrowsAsync<PartitionMismatchException>(async () => await _dbSet.UpdateAsync(result));
    }

    [Fact]
    public async Task Should_Not_Update_If_Missing_ID_Changed()
    {
        var person = new TestPersonDbEntry
        {
            FirstName = "Johnny",
            LastName = "You know who"
        };

        await Assert.ThrowsAsync<InvalidModelException>(async () => await _dbSet.UpdateAsync(person));
    }

    [Fact]
    public async Task Should_Not_Update_If_ETag_Is_Missing()
    {
        var person = new TestPersonDbEntry
        {
            FirstName = "Johnny",
            LastName = "You know who"
        };

        var result = await _dbSet.CreateAsync(person);

        result.FirstName = "Mary";
        result.ETag = null;

        await Assert.ThrowsAsync<ETagMismatchException>(async () => await _dbSet.UpdateAsync(result));
    }

    [Fact]
    public async Task Should_Not_Update_If_ETag_Is_Mismatched()
    {
        var person = new TestPersonDbEntry
        {
            FirstName = "Johnny",
            LastName = "You know who"
        };

        var result = await _dbSet.CreateAsync(person);

        result.FirstName = "Mary";
        result.ETag = "1234";

        await Assert.ThrowsAsync<ETagMismatchException>(async () => await _dbSet.UpdateAsync(result));
    }

    [Fact]
    public async Task Should_Not_Update_If_ETag_Is_Old()
    {
        var person = new TestPersonDbEntry
        {
            FirstName = "Johnny",
            LastName = "You know who"
        };

        var result = await _dbSet.CreateAsync(person);

        result.FirstName = "Mary";
        await _dbSet.UpdateAsync(result);

        result.FirstName = "Bob";
        await Assert.ThrowsAsync<ETagMismatchException>(async () => await _dbSet.UpdateAsync(result));
    }

    [Fact]
    public async Task Should_Delete_By_Id()
    {
        var person = new TestPersonDbEntry
        {
            FirstName = "Johnny",
            LastName = "You know who"
        };

        var result = await _dbSet.CreateAsync(person);

        await _dbSet.DeleteAsync(result.Id!);

        //check object cannot be retrieved from the database because it should not exist anymore
        await Assert.ThrowsAsync<ItemNotFoundException>(
            async () => await _dbSet.GetAsync(result.Id!));
    }

    [Fact]
    public async Task Should_Not_Delete_If_Object_Does_Not_Exist()
    {
        var person = new TestPersonDbEntry
        {
            Id = Guid.NewGuid().ToString(),
            FirstName = "Johnny",
            LastName = "You know who"
        };

        await Assert.ThrowsAsync<ItemNotFoundException>(async () => await _dbSet.DeleteAsync(person.Id));
    }
}