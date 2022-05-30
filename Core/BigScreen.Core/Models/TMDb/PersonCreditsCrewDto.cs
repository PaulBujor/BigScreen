using BigScreen.Core.Models.TMDb.Base;
using Newtonsoft.Json;

namespace BigScreen.Core.Models.TMDb;

public class PersonCreditsCrewDto : BasePersonCreditsMedia
{
    [JsonProperty(PropertyName = "job")]
    public string? Job { get; set; }
    
    [JsonProperty(PropertyName = "department")]
    public string? Department { get; set; }
}