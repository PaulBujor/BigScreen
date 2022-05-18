using BigScreen.SDK.DataAccess.Core;
using BigScreen.SDK.DataAccess.Core.Attributes;
using Newtonsoft.Json;

namespace BigScreen.SDK.DataAccess.Test.Models.DbContainerAttributeTest;

[DbContainer(ContainerName = "IncorrectUnnamed")]
public class IncorrectDbEntryWithoutName : BaseDbEntry
{
    [JsonProperty("somePartition")] public string? SomePartition { get; set; }
}