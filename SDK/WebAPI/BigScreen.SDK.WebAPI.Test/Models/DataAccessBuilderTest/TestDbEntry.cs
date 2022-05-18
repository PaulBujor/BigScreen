using BigScreen.SDK.DataAccess.Core;
using BigScreen.SDK.DataAccess.Core.Attributes;

namespace BigScreen.SDK.WebAPI.Test.Models.DataAccessBuilderTest;

[DbContainer(PartitionKey = "Test")]
public class TestDbEntry : BaseDbEntry
{
    public string? Test { get; set; }
}