using BigScreen.SDK.DataAccess.Attributes;
using BigScreen.SDK.DataAccess.Core;
using Newtonsoft.Json;

namespace BigScreen.SDK.DataAccess.Test.Models.CosmosBuilderTest;

[DbContainer(ContainerName = "Test", PartitionKey = "EntryName")]
public class TestDbEntry : BaseDbEntry
{
    [JsonProperty("EntityName")] public string? EntryName { get; set; }
}