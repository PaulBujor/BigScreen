using BigScreen.Frontend.Core;
using BigScreen.Frontend.Core.Attributes;
using Newtonsoft.Json;

namespace BigScreen.Core.Models.TMDb;

[TmdbDto("movie")]
public class MovieDto : TmdbDto
{
    [JsonProperty(PropertyName = "id")] public int Id { get; set; }

    [JsonProperty(PropertyName = "title")] public string Title { get; set; }

    [JsonProperty(PropertyName = "release_date")]
    public DateTime ReleaseDate { get; set; }

    [JsonProperty(PropertyName = "revenue")]
    public long Revenue { get; set; }

    [JsonProperty(PropertyName = "budget")]
    public long Budget { get; set; }

    [JsonProperty(PropertyName = "vote_average")]
    public double TmdbScore { get; set; }

    [JsonProperty(PropertyName = "genres")]
    public IEnumerable<GenreDto> Genres { get; set; }
}