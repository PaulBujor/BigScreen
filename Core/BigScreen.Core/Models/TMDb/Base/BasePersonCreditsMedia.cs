using BigScreen.Frontend.Core.Enums;
using BigScreen.Frontend.Core.Helpers;
using Newtonsoft.Json;

namespace BigScreen.Core.Models.TMDb.Base;

public class BasePersonCreditsMedia
{
    [JsonProperty(PropertyName = "id")]
    public int Id { get; set; }

    [JsonProperty(PropertyName = "name")]
    public string? Name { get; set; }

    [JsonProperty(PropertyName = "media_type")]
    public string? Type { get; set; }

    [JsonProperty(PropertyName = "overview")]
    public string? Overview { get; set; }

    [JsonIgnore]
    public string? ImageUrl { get; set; }

    [JsonIgnore]
    public DateOnly? ReleaseDate { get; set; }

    [JsonProperty(PropertyName = "title")]
    private string? Title
    {
        set => Name = value;
    }

    [JsonProperty(PropertyName = "poster_path")]
    private string? PosterPath
    {
        set => ImageUrl = TmdbImageHelper.GetImageUrl(value, ImageSize.InGeneralPage);
    }

    [JsonProperty(PropertyName = "release_date")]
    private string? Date
    {
        set
        {
            if (!string.IsNullOrEmpty(value))
            {
                ReleaseDate = DateOnly.Parse(value);
            }
        }
    }

    [JsonProperty(PropertyName = "first_air_date")]
    private string? FirstEpisodeDate
    {
        set
        {
            if (!string.IsNullOrEmpty(value))
            {
                ReleaseDate = DateOnly.Parse(value);
            }
        }
    }
}