using BigScreen.SDK.DataAccess.Core;
using BigScreen.SDK.DataAccess.Core.Attributes;
using Newtonsoft.Json;

namespace BigScreen.SDK.DataAccess.Test.Models.CosmosBuilderTest;

[DbContainer(ContainerName = "AnotherTest", PartitionKey = "AnotherEntryName")]
public class AnotherTestDbEntry : BaseDbEntry
{
    [JsonProperty("AnotherEntryName")] public string? AnotherEntryName { get; set; }
}