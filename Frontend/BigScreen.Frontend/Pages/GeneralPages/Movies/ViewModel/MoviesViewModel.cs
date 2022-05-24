using BigScreen.Core.Models.TMDb;
using BigScreen.Frontend.Client.Handlers.Interfaces;
using BigScreen.Frontend.Components.GeneralPageLayout.Models;
using BigScreen.Frontend.Core.Enums;

namespace BigScreen.Frontend.Pages.GeneralPages.Movies.ViewModel;

public class MoviesViewModel : IMoviesViewModel
{
    private readonly IGeneralSearchPageResults<MoviesGeneralSearchResultsDto> _handler;


    public MoviesViewModel(IGeneralSearchPageResults<MoviesGeneralSearchResultsDto> handler)
    {
        _handler = handler;
    }

    public MoviesGeneralSearchResultsDto? PageResults { get; private set; }

    public async Task CallSearch(SortFilter sortFilter, int page)
    {
        PageResults = await _handler.GetGeneralSearchBySortType(sortFilter, page);
    }

    public async Task OnSearchContextChanged(SearchContext searchContext)
    {
        await CallSearch(searchContext.SortFilter, searchContext.Page);
    }
}