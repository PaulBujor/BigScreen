using BigScreen.Frontend.Core.Enums;
using BigScreen.Frontend.Core.Helpers;
using Newtonsoft.Json;

namespace BigScreen.Core.Models.TMDb;

public class SearchResultDto
{
    [JsonProperty(PropertyName = "id")] public int Id { get; set; }
    [JsonProperty(PropertyName = "name")] public string? Name { get; set; }
    [JsonProperty(PropertyName = "title")] private string? Title
    {
        set => Name = value;
    }

    [JsonProperty(PropertyName = "media_type")]
    public string? Type { get; set; }

    [JsonIgnore] public string? ImageUrl { get; set; }

    [JsonProperty(PropertyName = "poster_path")]
    private string? ImagePath
    {
        set => ImageUrl = TmdbImageHelper.GetImageUrl(value, ImageSize.InSearch);
    }

    [JsonProperty(PropertyName = "profile_path")]
    private string? ProfileImagePath
    {
        set => ImageUrl = TmdbImageHelper.GetImageUrl(value, ImageSize.InSearch);
    }
}