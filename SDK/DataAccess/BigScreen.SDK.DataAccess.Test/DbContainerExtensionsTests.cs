using System;
using BigScreen.SDK.DataAccess.Extensions;
using BigScreen.SDK.DataAccess.Test.Models.DbContainerExtensionsTest;
using Xunit;

namespace BigScreen.SDK.DataAccess.Test;

public class DbContainerExtensionsTests
{
    [Fact]
    public void Should_Retrieve_Partition_Key_Value_If_Case_Match()
    {
        var dbEntry = new CorrectlyNestedPartitionKeyDbEntry
        {
            BigObject = new NestedCorrectly
            {
                Partition = "magic"
            }
        };

        Assert.Equal(dbEntry.BigObject.Partition, dbEntry.GetPartitionKeyValue());
    }

    [Fact]
    public void Should_Retrieve_Partition_Key_Value_If_Case_Not_Match()
    {
        var dbEntry = new IncorrectlyNestedPartitionKeyDbEntry
        {
            BigObject = new NestedIncorrectly
            {
                Partition = "magic"
            }
        };

        Assert.Equal(dbEntry.BigObject.Partition, dbEntry.GetPartitionKeyValue());
    }

    [Fact]
    public void Should_Throw_Exception_If_Partition_Key_Is_Not_String()
    {
        var dbEntry = new WrongPartitionKeyTypeDbEntry
        {
            NonString = 1
        };

        Assert.Throws<InvalidCastException>(() => dbEntry.GetPartitionKeyValue());
    }
}