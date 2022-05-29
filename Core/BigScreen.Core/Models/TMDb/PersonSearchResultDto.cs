using BigScreen.Core.Models.TMDb.Base;
using BigScreen.Frontend.Core.Enums;
using BigScreen.Frontend.Core.Helpers;
using Newtonsoft.Json;

namespace BigScreen.Core.Models.TMDb;

public class PersonSearchResultDto
{
    [JsonProperty(PropertyName = "id")]
    public int Id { get; set; }

    [JsonProperty(PropertyName = "name")]
    public string? Name { get; set; }

    [JsonProperty(PropertyName = "overview")]
    public string? Overview { get; set; }

    [JsonProperty(PropertyName = "known_for")]
    public IEnumerable<BaseMediaSearchResultDto>? KnownFor { get; set; }

    [JsonIgnore]
    public string? ImageUrl { get; set; }

    [JsonProperty(PropertyName = "profile_path")]
    private string? ProfilePath
    {
        set => ImageUrl = TmdbImageHelper.GetImageUrl(value, ImageSize.InGeneralPage);
    }
}