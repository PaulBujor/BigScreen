using Newtonsoft.Json;

namespace BigScreen.Core.Models.TMDb.Base;

public class BaseMediaCastPerson : BaseMediaCreditsPerson
{
    [JsonProperty(PropertyName = "character")]
    public string? Character { get; set; }
}