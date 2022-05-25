using BigScreen.Core.Models.TMDb;
using BigScreen.Frontend.Components.GeneralPageLayout.Models;
using BigScreen.Frontend.Core.Enums;
using BigScreen.Frontend.Pages.GeneralPages.ViewModel;

namespace BigScreen.Frontend.Pages.GeneralPages.People.ViewModel;

public interface IPeopleViewModel : IBaseGeneralPageViewModel<PeopleSearchResultsDto>
{
    string GetCardOverview(PersonSearchResultDto person);
}