using BigScreen.SDK.DataAccess.Core;
using BigScreen.SDK.DataAccess.Core.Attributes;

namespace BigScreen.Backend.Models;

[DbContainer(PartitionKey = nameof(PartitionKey))]
public class TestDbEntry : BaseDbEntry
{
    //TODO remove later
    public string? PartitionKey { get; set; }
    public string? Name { get; set; }
}