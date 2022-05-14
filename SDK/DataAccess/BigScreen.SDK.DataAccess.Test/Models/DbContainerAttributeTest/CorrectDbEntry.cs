using BigScreen.SDK.DataAccess.Attributes;
using BigScreen.SDK.DataAccess.Core;
using Newtonsoft.Json;

namespace BigScreen.SDK.DataAccess.Test.Models.DbContainerAttributeTest;

[DbContainer(ContainerName = "Correct", PartitionKey = "somePartition")]
public class CorrectDbEntry : BaseDbEntry
{
    [JsonProperty("somePartition")] public string? SomePartition { get; set; }
}