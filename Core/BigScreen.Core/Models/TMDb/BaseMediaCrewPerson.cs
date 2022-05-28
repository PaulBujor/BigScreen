using Newtonsoft.Json;

namespace BigScreen.Core.Models.TMDb;

public class BaseMediaCrewPerson : BaseMediaCreditsPerson
{
    [JsonProperty(PropertyName = "job")]
    public string? Job { get; set; }
}