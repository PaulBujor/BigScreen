using BigScreen.Core.Models.TMDb;
using BigScreen.Frontend.Client.Handlers.Interfaces;
using BigScreen.Frontend.Pages.GeneralPages.ViewModel;

namespace BigScreen.Frontend.Pages.GeneralPages.Movies.ViewModel;

public class MoviesViewModel : BaseGeneralPageViewModel<MoviesSearchResultsDto>, IMoviesViewModel
{
    public MoviesViewModel(IGeneralSearchPageResultsHandler<MoviesSearchResultsDto> handler) : base(handler)
    {
    }
}