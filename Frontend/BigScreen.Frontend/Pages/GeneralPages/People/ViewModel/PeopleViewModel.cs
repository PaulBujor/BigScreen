using BigScreen.Core.Models.TMDb;
using BigScreen.Frontend.Client.Handlers.Interfaces;
using BigScreen.Frontend.Pages.GeneralPages.ViewModel;

namespace BigScreen.Frontend.Pages.GeneralPages.People.ViewModel;

public class PeopleViewModel : BaseGeneralPageViewModel<PeopleSearchResultsDto>, IPeopleViewModel
{
    private IPeopleViewModel _peopleViewModelImplementation;

    public PeopleViewModel(IGeneralSearchPageResultsHandler<PeopleSearchResultsDto> handler) : base(handler)
    {
    }

    public string GetCardOverview(PersonSearchResultDto person)
    {
        var overview = string.Empty;
        var titles = person.KnownFor?.Take(3).Select(s => s.Name).ToArray();
        if (titles != null)
        {
            overview = string.Join("; ", titles);
        }

        return overview;
    }
}