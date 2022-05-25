using BigScreen.Core.Models.TMDb;
using BigScreen.Frontend.Client.Handlers.Interfaces;
using BigScreen.Frontend.Components.GeneralPageLayout.Models;
using BigScreen.Frontend.Core.Enums;
using BigScreen.Frontend.Pages.GeneralPages.ViewModel;

namespace BigScreen.Frontend.Pages.GeneralPages.Movies.ViewModel;

public class MoviesViewModel : BaseGeneralPageViewModel<MoviesSearchResultsDto>, IMoviesViewModel
{
    public MoviesViewModel(IGeneralSearchPageResults<MoviesSearchResultsDto> handler) : base(handler)
    {
    }
}