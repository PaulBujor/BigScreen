using BigScreen.Core.Models.TMDb;
using BigScreen.Core.Models.TMDb.Base;
using BigScreen.Frontend.Client.Handlers.Interfaces;
using BigScreen.Frontend.Components.Card;
using BigScreen.Frontend.Pages.DetailsPages.Person.Models;

namespace BigScreen.Frontend.Pages.DetailsPages.Person.ViewModel;

public class PersonViewModel : IPersonViewModel
{
    private readonly IPersonHandler _personHandler;

    public int Id { get; set; }
    public PersonDto? PersonDetails { get; private set; }

    public string GetDateOnlyText(DateOnly? date) => date is not null
        ? date.Value.ToString("dd/MM/yyyy")
        : string.Empty;

    public string GetMediaCardHeader<TCreditsType>(TCreditsType obj) where TCreditsType : BasePersonCreditsMedia
    {
        var header = obj.Name ?? string.Empty;
        if (obj.ReleaseDate is not null)
        {
            var year = obj.ReleaseDate?.Year.ToString();
            header += $" ({year})";
        }

        return header;
    }

    public void GetCrewByDepartment()
    {
        CrewByDepartment = PersonDetails?.Credits?.Crew?.GroupBy(v => v.Department)
            .Select(gr => new CrewByDepartment()
            {
                Department = gr.Key,
                List = gr
            }).ToList();
    }

    public IEnumerable<CrewByDepartment>? CrewByDepartment { get; private set; }


    public PersonViewModel(IPersonHandler personHandler)
    {
        _personHandler = personHandler;
    }

    public async Task GetPersonDetails() => PersonDetails = await _personHandler.GetPerson(Id);
}