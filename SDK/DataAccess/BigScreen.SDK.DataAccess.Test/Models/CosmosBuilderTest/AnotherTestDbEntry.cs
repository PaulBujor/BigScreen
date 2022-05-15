using BigScreen.SDK.DataAccess.Attributes;
using BigScreen.SDK.DataAccess.Core;
using Newtonsoft.Json;

namespace BigScreen.SDK.DataAccess.Test.Models.CosmosBuilderTest;

[DbContainer(ContainerName = "AnotherTest", PartitionKey = "AnotherEntryName")]
public class AnotherTestDbEntry : BaseDbEntry
{
    [JsonProperty("AnotherEntryName")] public string? AnotherEntryName { get; set; }
}