using Newtonsoft.Json;

namespace BigScreen.SDK.DataAccess.Core;

public abstract class BaseDbObject
{
    [JsonProperty("id")] public string? Id { get; set; }
}