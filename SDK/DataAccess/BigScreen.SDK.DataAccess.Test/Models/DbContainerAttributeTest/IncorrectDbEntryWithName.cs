using BigScreen.SDK.DataAccess.Core;
using BigScreen.SDK.DataAccess.Core.Attributes;
using Newtonsoft.Json;

namespace BigScreen.SDK.DataAccess.Test.Models.DbContainerAttributeTest;

[DbContainer(ContainerName = "IncorrectNamed")]
public class IncorrectDbEntryWithName : BaseDbEntry
{
    [JsonProperty("somePartition")] public string? SomePartition { get; set; }
}