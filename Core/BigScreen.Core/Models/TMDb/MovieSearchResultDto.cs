using System.Globalization;
using BigScreen.Frontend.Core.Enums;
using BigScreen.Frontend.Core.Helpers;
using Newtonsoft.Json;

namespace BigScreen.Core.Models.TMDb;

public class MovieSearchResultDto
{
    [JsonProperty(PropertyName = "id")]
    public int Id { get; set; }

    [JsonProperty(PropertyName = "title")]
    public string? Name { get; set; }
    
    [JsonProperty(PropertyName = "overview")]
    public string? Overview { get; set; }
    
    [JsonProperty(PropertyName = "vote_average")]
    public double? TmdbRating { get; set; }
    
    [JsonIgnore]
    public string? ImageUrl { get; set; }
    
    [JsonIgnore]
    public DateOnly? ReleaseDate { get; set; }

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
}