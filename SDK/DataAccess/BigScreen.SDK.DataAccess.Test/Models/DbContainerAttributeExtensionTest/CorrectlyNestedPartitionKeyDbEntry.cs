using BigScreen.SDK.DataAccess.Core;
using BigScreen.SDK.DataAccess.Core.Attributes;
using Newtonsoft.Json;

namespace BigScreen.SDK.DataAccess.Test.Models.DbContainerAttributeExtensionTest;

[DbContainer(PartitionKey = "/BigObject/Partition")]
public class CorrectlyNestedPartitionKeyDbEntry : BaseDbEntry
{
    [JsonProperty("BigObject")] public NestedCorrectly? BigObject { get; set; }
}

public class NestedCorrectly
{
    [JsonProperty("Partition")] public string? Partition { get; set; }
}