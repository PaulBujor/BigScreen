using Newtonsoft.Json;

namespace BigScreen.Core.Models.TMDb;

public class TvShowSearchResultDto : BaseMediaSearchResultDto
{
    [JsonIgnore]
    public DateOnly? FirstEpisodeDate { get; set; }
    
    [JsonProperty(PropertyName = "first_air_date")]
    private string? Date
    {
        set
        {
            if (!string.IsNullOrEmpty(value))
            {
                FirstEpisodeDate = DateOnly.Parse(value);
            }
        }
    }
}