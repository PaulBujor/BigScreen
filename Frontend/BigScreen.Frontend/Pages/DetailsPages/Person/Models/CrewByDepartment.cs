using BigScreen.Core.Models.TMDb;

namespace BigScreen.Frontend.Pages.DetailsPages.Person.Models;

public class CrewByDepartment
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string? Department { get; set; }
    public IEnumerable<PersonCreditsCrewDto>? List { get; set; }
}