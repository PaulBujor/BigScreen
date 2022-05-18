using BigScreen.SDK.DataAccess.Core;
using Newtonsoft.Json;

namespace BigScreen.SDK.DataAccess.Test.Models.DbContainerAttributeTest;

public class IncorrectDbEntryWithoutAttribute : BaseDbEntry
{
    [JsonProperty("whatever")] public string? DontHaveAnAttribute { get; set; }
}