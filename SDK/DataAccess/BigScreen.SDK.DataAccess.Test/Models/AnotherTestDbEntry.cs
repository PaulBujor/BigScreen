using BigScreen.SDK.DataAccess.Core;
using Newtonsoft.Json;

namespace BigScreen.SDK.DataAccess.Test.Models;

public class AnotherTestDbEntry : BaseDbEntry
{
    [JsonProperty("AnotherEntryName")] public string? AnotherEntryName { get; set; }
}