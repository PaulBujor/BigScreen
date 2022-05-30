using BigScreen.Core.Models.TMDb;
using BigScreen.Core.Models.TMDb.Base;
using BigScreen.Frontend.Pages.DetailsPages.Person.Models;

namespace BigScreen.Frontend.Pages.DetailsPages.Person.ViewModel;

public interface IPersonViewModel
{
    int Id { get; set; }
    PersonDto? PersonDetails { get; }
    IEnumerable<CrewByDepartment>? CrewByDepartment { get; }
    Task GetPersonDetails();
    string GetDateOnlyText(DateOnly? date);
    string GetMediaCardHeader<TCreditsType>(TCreditsType obj) where TCreditsType : BasePersonCreditsMedia;
    void GetCrewByDepartment();
}