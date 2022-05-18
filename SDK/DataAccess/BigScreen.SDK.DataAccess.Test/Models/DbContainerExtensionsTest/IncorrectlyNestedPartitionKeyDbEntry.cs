using BigScreen.SDK.DataAccess.Core;
using BigScreen.SDK.DataAccess.Core.Attributes;
using Newtonsoft.Json;

namespace BigScreen.SDK.DataAccess.Test.Models.DbContainerExtensionsTest;

[DbContainer(PartitionKey = "/bigObject/partition")]
public class IncorrectlyNestedPartitionKeyDbEntry : BaseDbEntry
{
    [JsonProperty("BigObject")] public NestedIncorrectly? BigObject { get; set; }
}

public class NestedIncorrectly
{
    [JsonProperty("Partition")] public string? Partition { get; set; }
}