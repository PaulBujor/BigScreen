using BigScreen.Core.Models.TMDb.Base;
using Newtonsoft.Json;

namespace BigScreen.Core.Models.TMDb;

public class PersonCreditsCastDto : BasePersonCreditsMedia
{
    [JsonProperty(PropertyName = "character")]
    public string? Character { get; set; }
}