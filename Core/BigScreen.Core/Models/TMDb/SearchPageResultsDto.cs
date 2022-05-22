using BigScreen.Frontend.Core;
using BigScreen.Frontend.Core.Attributes;
using Newtonsoft.Json;

namespace BigScreen.Core.Models.TMDb;

[TmdbDto("search")]
public class SearchPageResultsDto : TmdbDto
{
    [JsonProperty(PropertyName = "page")] public int Page { get; set; }
    [JsonProperty(PropertyName = "results")] public IEnumerable<SearchResultDto>? Results { get; set; }
    [JsonProperty(PropertyName = "total_pages")] public int TotalPages { get; set; }
    [JsonProperty(PropertyName = "total_results")] public int TotalResults { get; set; }
}