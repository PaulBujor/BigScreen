using BigScreen.SDK.DataAccess.Core;
using BigScreen.SDK.DataAccess.Core.Attributes;
using Newtonsoft.Json;

namespace BigScreen.SDK.DataAccess.Test.Models.DbContainerAttributeTest;

[DbContainer(PartitionKey = "somePartition")]
public class UnnamedDbEntry : BaseDbEntry
{
    [JsonProperty("somePartition")] public string? SomePartition { get; set; }
}