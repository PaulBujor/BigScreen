using BigScreen.SDK.DataAccess.Core;
using BigScreen.SDK.DataAccess.Core.Attributes;
using Newtonsoft.Json;

namespace BigScreen.SDK.DataAccess.Test.Models.CosmosBuilderTest;

[DbContainer(ContainerName = "Test", PartitionKey = "EntryName")]
public class TestDbEntry : BaseDbEntry
{
    [JsonProperty("EntityName")] public string? EntryName { get; set; }
}