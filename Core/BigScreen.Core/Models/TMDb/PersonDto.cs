using BigScreen.Frontend.Core;
using BigScreen.Frontend.Core.Attributes;
using BigScreen.Frontend.Core.Enums;
using BigScreen.Frontend.Core.Helpers;
using Newtonsoft.Json;

namespace BigScreen.Core.Models.TMDb;

[TmdbDto("person")]
public class PersonDto : TmdbDto
{
    [JsonProperty(PropertyName = "id")]
    public int Id { get; set; }

    [JsonProperty(PropertyName = "name")]
    public string? Name { get; set; }

    [JsonIgnore]
    public string? ImageUrl { get; set; }

    [JsonProperty(PropertyName = "known_for_department")]
    public string? KnownFor { get; set; }

    [JsonProperty(PropertyName = "biography")]
    public string? Biography { get; set; }

    [JsonProperty(PropertyName = "place_of_birth")]
    public string? PlaceOfBirth { get; set; }

    [JsonProperty(PropertyName = "combined_credits")]
    public PersonCreditsDto? Credits { get; set; }

    [JsonIgnore]
    public DateOnly? Birthday { get; set; }

    [JsonIgnore]
    public DateOnly? Deathday { get; set; }

    [JsonProperty(PropertyName = "birthday")]
    private string? BirthDate
    {
        set
        {
            if (!string.IsNullOrEmpty(value))
            {
                Birthday = DateOnly.Parse(value);
            }
        }
    }

    [JsonProperty(PropertyName = "deathday")]
    private string? DeathDate
    {
        set
        {
            if (!string.IsNullOrEmpty(value))
            {
                Deathday = DateOnly.Parse(value);
            }
        }
    }

    [JsonProperty(PropertyName = "profile_path")]
    private string? PosterPath
    {
        set => ImageUrl = TmdbImageHelper.GetImageUrl(value, ImageSize.InDetailsPage);
    }
}