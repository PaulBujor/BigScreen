using Newtonsoft.Json;

namespace BigScreen.Core.Models.TMDb.Base;

public class BaseMediaCrewPerson : BaseMediaCreditsPerson
{
    [JsonProperty(PropertyName = "job")]
    public string? Job { get; set; }
}