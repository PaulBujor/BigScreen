using BigScreen.SDK.DataAccess.Core;
using BigScreen.SDK.DataAccess.Core.Attributes;
using Newtonsoft.Json;

namespace BigScreen.SDK.DataAccess.Test.Models.DbContainerAttributeTest;

[DbContainer(PartitionKey = "/BigObject/Partition")]
public class CorrectDbEntryWIthNestedPartitionKey : BaseDbEntry
{
    [JsonProperty("BigObject")] public NestedOreo? BigObject { get; set; }
}

public class NestedOreo
{
    [JsonProperty("Partition")] public string? Partition { get; set; }
}