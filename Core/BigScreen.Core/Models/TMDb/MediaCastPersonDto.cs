using BigScreen.Core.Models.TMDb.Base;
using Newtonsoft.Json;

namespace BigScreen.Core.Models.TMDb;

public class MediaCastPersonDto : BaseMediaCreditsPerson
{
    [JsonProperty(PropertyName = "character")]
    public string? Character { get; set; }
}