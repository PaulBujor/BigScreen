using BigScreen.SDK.DataAccess.Core;
using Newtonsoft.Json;

namespace BigScreen.SDK.DataAccess.Test.Models;

public class TestDbEntry : BaseDbEntry
{
    [JsonProperty("EntityName")] public string? EntryName { get; set; }
}