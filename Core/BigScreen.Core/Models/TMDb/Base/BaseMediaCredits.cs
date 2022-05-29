using Newtonsoft.Json;

namespace BigScreen.Core.Models.TMDb.Base;

public class BaseMediaCredits
{
    [JsonProperty(PropertyName = "cast")]
    public IEnumerable<BaseMediaCastPerson>? Cast { get; set; }

    [JsonIgnore]
    public IEnumerable<BaseMediaCrewPerson>? Crew { get; set; }

    [JsonProperty(PropertyName = "crew")]
    public IEnumerable<BaseMediaCrewPerson>? CrewRaw
    {
        set
        {
            Crew = value?.GroupBy(v => new { v.Id, v.Name, v.Department, Image = v.ImageUrl })
                .Select(gr => new BaseMediaCrewPerson
                {
                    Id = gr.Key.Id,
                    Name = gr.Key.Name,
                    Department = gr.Key.Department,
                    ImageUrl = gr.Key.Image,
                    Job = string.Join(", ", gr.Select(x => x.Job).ToArray())
                });
        }
    }
}