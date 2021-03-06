using BigScreen.Core.Models.TMDb;
using BigScreen.Frontend.Pages.GeneralPages.ViewModel;

namespace BigScreen.Frontend.Pages.GeneralPages.People.ViewModel;

public interface IPeopleViewModel : IBaseGeneralPageViewModel<PeopleSearchResultsDto>
{
    string GetCardOverview(PersonSearchResultDto person);
}