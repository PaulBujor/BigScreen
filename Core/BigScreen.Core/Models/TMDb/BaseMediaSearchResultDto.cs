using BigScreen.Frontend.Core.Enums;
using BigScreen.Frontend.Core.Helpers;
using Newtonsoft.Json;

namespace BigScreen.Core.Models.TMDb;

public class BaseMediaSearchResultDto
{
    [JsonProperty(PropertyName = "id")]
    public int Id { get; set; }
    
    [JsonProperty(PropertyName = "name")]
    public string? Name { get; set; }

    [JsonProperty(PropertyName = "title")]
    private string? Title
    {
        set => Name = value;
    }
    
    [JsonProperty(PropertyName = "overview")]
    public string? Overview { get; set; }
    
    [JsonProperty(PropertyName = "vote_average")]
    public double? TmdbRating { get; set; }
    
    [JsonIgnore]
    public string? ImageUrl { get; set; }
    
    [JsonProperty(PropertyName = "poster_path")]
    private string? PosterPath
    {
        set => ImageUrl = TmdbImageHelper.GetImageUrl(value, ImageSize.InGeneralPage);
    }
}