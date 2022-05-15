using Newtonsoft.Json;

namespace BigScreen.SDK.DataAccess.Core;

public abstract class BaseDbEntry : BaseDbObject
{
    [JsonProperty("_etag")] public string? ETag { get; set; }
}