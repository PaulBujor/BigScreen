using BigScreen.Frontend.Core;
using BigScreen.Frontend.Core.Attributes;
using Newtonsoft.Json;

namespace BigScreen.Core.Models.TMDb;
[TmdbDto("genre")]
public class GenreDto : TmdbDto
{
    [JsonProperty(PropertyName = "id")]
    public int Id { get; set; }

    [JsonProperty(PropertyName = "name")]
    public string Name { get; set; }
}