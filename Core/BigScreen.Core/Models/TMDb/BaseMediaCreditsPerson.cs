using BigScreen.Frontend.Core.Enums;
using BigScreen.Frontend.Core.Helpers;
using Newtonsoft.Json;

namespace BigScreen.Core.Models.TMDb;

public class BaseMediaCreditsPerson
{
    [JsonProperty(PropertyName = "id")]
    public int Id { get; set; }

    [JsonProperty(PropertyName = "name")]
    public string? Name { get; set; }

    [JsonProperty(PropertyName = "known_for_department")]
    public string? Department { get; set; }

    [JsonIgnore]
    public string? ImageUrl { get; set; }

    [JsonProperty(PropertyName = "profile_path")]
    private string? ProfilePath
    {
        set => ImageUrl = TmdbImageHelper.GetImageUrl(value, ImageSize.InGeneralPage);
    }
}