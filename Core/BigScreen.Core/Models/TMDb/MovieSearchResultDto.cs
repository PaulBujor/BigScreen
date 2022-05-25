using System.Globalization;
using BigScreen.Frontend.Core.Enums;
using BigScreen.Frontend.Core.Helpers;
using Newtonsoft.Json;

namespace BigScreen.Core.Models.TMDb;

public class MovieSearchResultDto : BaseMediaSearchResultDto
{
    [JsonIgnore]
    public DateOnly? ReleaseDate { get; set; }
    
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