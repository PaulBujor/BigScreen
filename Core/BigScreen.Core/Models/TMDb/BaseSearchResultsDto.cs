using BigScreen.Frontend.Core;
using Newtonsoft.Json;

namespace BigScreen.Core.Models.TMDb;

public class BaseSearchResultsDto<TResultType> : TmdbDto where TResultType : class
{
    [JsonProperty(PropertyName = "page")]
    public int Page { get; set; }

    [JsonProperty(PropertyName = "results")]
    public IEnumerable<TResultType> Results { get; set; } = null!;

    [JsonProperty(PropertyName = "total_pages")]
    public int TotalPages { get; set; }

    [JsonProperty(PropertyName = "total_results")]
    public int TotalResults { get; set; }
}