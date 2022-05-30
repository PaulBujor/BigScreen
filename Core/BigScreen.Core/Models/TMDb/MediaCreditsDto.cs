using BigScreen.Core.Models.TMDb.Base;
using Newtonsoft.Json;

namespace BigScreen.Core.Models.TMDb;

public class MediaCreditsDto
{
    [JsonProperty(PropertyName = "cast")]
    public IEnumerable<MediaCastPersonDto>? Cast { get; set; }

    [JsonIgnore]
    public IEnumerable<MediaCrewPersonDto>? Crew { get; set; }

    [JsonProperty(PropertyName = "crew")]
    private IEnumerable<MediaCrewPersonDto>? CrewRaw
    {
        set
        {
            Crew = value?.GroupBy(v => new { v.Id, v.Name, v.Department, v.ImageUrl })
                .Select(gr => new MediaCrewPersonDto
                {
                    Id = gr.Key.Id,
                    Name = gr.Key.Name,
                    Department = gr.Key.Department,
                    ImageUrl = gr.Key.ImageUrl,
                    Job = string.Join(", ", gr.Select(x => x.Job).ToArray())
                });
        }
    }
}