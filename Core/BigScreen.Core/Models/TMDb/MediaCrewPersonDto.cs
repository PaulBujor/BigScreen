using BigScreen.Core.Models.TMDb.Base;
using Newtonsoft.Json;

namespace BigScreen.Core.Models.TMDb;

public class MediaCrewPersonDto : BaseMediaCreditsPerson
{
    [JsonProperty(PropertyName = "job")]
    public string? Job { get; set; }
}