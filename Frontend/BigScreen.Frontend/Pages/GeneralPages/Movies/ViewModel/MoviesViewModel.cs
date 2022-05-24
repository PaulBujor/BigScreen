using BigScreen.Core.Models.TMDb;
using BigScreen.Frontend.Client.Handlers.Interfaces;
using BigScreen.Frontend.Core.Enums;

namespace BigScreen.Frontend.Pages.GeneralPages.Movies.ViewModel;

public class MoviesViewModel : IMoviesViewModel
{
    private readonly IGeneralSearchPageResults<MoviesGeneralSearchResultsDto> _handler;

    public MoviesGeneralSearchResultsDto? Results { get; private set; }

    
    public MoviesViewModel(IGeneralSearchPageResults<MoviesGeneralSearchResultsDto> handler)
    {
        _handler = handler;
    }

    public async Task CallSearch(SortFilter sortFilter)
    {
        Results = await _handler.GetGeneralSearchBySortType(sortFilter);
    }
}