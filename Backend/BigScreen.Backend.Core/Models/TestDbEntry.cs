using BigScreen.SDK.DataAccess.Core;
using BigScreen.SDK.DataAccess.Core.Attributes;

namespace BigScreen.Backend.Core.Models;

[DbContainer(PartitionKey = nameof(PartitionKey))]
public class TestDbEntry : BaseDbEntry
{
    public string? PartitionKey { get; set; }
    public string? Name { get; set; }
}