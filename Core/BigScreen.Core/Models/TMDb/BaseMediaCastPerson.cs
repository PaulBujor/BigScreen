using Newtonsoft.Json;

namespace BigScreen.Core.Models.TMDb;

public class BaseMediaCastPerson : BaseMediaCreditsPerson
{
    [JsonProperty(PropertyName = "character")]
    public string? Character { get; set; }
}