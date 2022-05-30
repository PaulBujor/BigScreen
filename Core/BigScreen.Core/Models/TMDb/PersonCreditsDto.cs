using Newtonsoft.Json;

namespace BigScreen.Core.Models.TMDb;

public class PersonCreditsDto
{
    [JsonProperty(PropertyName = "cast")]
    public IEnumerable<PersonCreditsCastDto>? Cast { get; set; }

    [JsonIgnore]
    public IEnumerable<PersonCreditsCrewDto>? Crew { get; set; }

    [JsonProperty(PropertyName = "crew")]
    private IEnumerable<PersonCreditsCrewDto>? CrewRaw
    {
        set
        {
            Crew = value?.GroupBy(v => new { v.Id, v.Name, v.Department, v.ImageUrl, v.Type })
                .Select(gr => new PersonCreditsCrewDto
                {
                    Id = gr.Key.Id,
                    Name = gr.Key.Name,
                    Department = gr.Key.Department,
                    ImageUrl = gr.Key.ImageUrl,
                    Type = gr.Key.Type,
                    Job = string.Join(", ", gr.Select(x => x.Job).ToArray())
                });
        }
    }
}