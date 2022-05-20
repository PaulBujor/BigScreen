using BigScreen.SDK.DataAccess.Core;
using BigScreen.SDK.DataAccess.Core.Attributes;

namespace BigScreen.SDK.WebAPI.Test.Models.DataAccessBuilderTest;

[DbContainer(PartitionKey = "Test")]
public class TestDbEntry : BaseDbEntry
{
    public string? Test { get; set; }
    public string? Test2 { get; set; }
    public string? Test3 { get; set; }
}