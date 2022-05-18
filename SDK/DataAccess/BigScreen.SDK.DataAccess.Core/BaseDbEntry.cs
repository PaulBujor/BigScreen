using Newtonsoft.Json;

namespace BigScreen.SDK.DataAccess.Core;

public abstract class BaseDbEntry : BaseDbObject
{
    [JsonProperty("_etag", NullValueHandling = NullValueHandling.Ignore)]
    public string? ETag { get; set; }
}