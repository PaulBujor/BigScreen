using BigScreen.Frontend.Core;
using BigScreen.Frontend.Core.Enums;
using BigScreen.Frontend.Core.Helpers;
using Newtonsoft.Json;

namespace BigScreen.Core.Models.TMDb.Base;

public class BaseMediaDetailsDto : TmdbDto
{
    [JsonProperty(PropertyName = "id")] public int Id { get; set; }

    [JsonProperty(PropertyName = "name")] public string? Name { get; set; }

    [JsonProperty(PropertyName = "vote_average")]
    public double? TmdbScore { get; set; }

    [JsonIgnore] public string? ImageUrl { get; set; }

    [JsonProperty(PropertyName = "overview")]
    public string? Overview { get; set; }

    [JsonIgnore] public DateOnly? ReleaseDate { get; set; }

    [JsonIgnore] public TimeSpan Duration { get; set; }

    [JsonProperty(PropertyName = "tagline")]
    public string? Tagline { get; set; }

    [JsonProperty(PropertyName = "status")]
    public string? Status { get; set; }

    [JsonProperty(PropertyName = "budget")]
    public double? Budget { get; set; }

    [JsonProperty(PropertyName = "revenue")]
    public double? Revenue { get; set; }

    [JsonProperty(PropertyName = "genres")]
    public IEnumerable<GenreDto?>? Genres { get; set; }

    [JsonProperty(PropertyName = "similar")]
    public BaseSearchResultsDto<BaseMediaSearchResultDto>? Similar { get; set; }

    [JsonProperty(PropertyName = "recommendations")]
    public BaseSearchResultsDto<BaseMediaSearchResultDto>? Recommendations { get; set; }

    [JsonProperty(PropertyName = "credits")]
    public MediaCreditsDto? Credits { get; set; }

    [JsonProperty(PropertyName = "title")]
    private string? Title
    {
        set => Name = value;
    }

    [JsonProperty(PropertyName = "poster_path")]
    private string? PosterPath
    {
        set
        {
            ImageUrl = TmdbImageHelper.GetImageUrl(value, ImageSize.InDetailsPage);
            ImageUrlSmall = TmdbImageHelper.GetImageUrl(value, ImageSize.InGeneralPage);
        }
    }

    [JsonIgnore] public string? ImageUrlSmall { get; private set; }

    [JsonProperty(PropertyName = "release_date")]
    private string? Date
    {
        set
        {
            if (!string.IsNullOrEmpty(value)) ReleaseDate = DateOnly.Parse(value);
        }
    }

    [JsonProperty(PropertyName = "first_air_date")]
    private string? FirstEpisodeDate
    {
        set
        {
            if (!string.IsNullOrEmpty(value)) ReleaseDate = DateOnly.Parse(value);
        }
    }

    [JsonProperty(PropertyName = "episode_run_time")]
    private int[]? EpisodeRuntime
    {
        set
        {
            if (value != null && value.Any()) Duration = TimeSpan.FromMinutes(value.First());
        }
    }

    [JsonProperty(PropertyName = "runtime")]
    private int? Runtime
    {
        set
        {
            if (value != null) Duration = TimeSpan.FromMinutes((double) value);
        }
    }
}