using BigScreen.Core.Models.TMDb;
using BigScreen.Frontend.Client.Handlers.Interfaces;
using BigScreen.Frontend.Components.GeneralPageLayout;
using BigScreen.Frontend.Components.GeneralPageLayout.Models;
using BigScreen.Frontend.Core.Enums;

namespace BigScreen.Frontend.Pages.Search.ViewModel;

public class SearchViewModel : ISearchViewModel
{
    private readonly ISearchPageResultsHandler _searchHandler;

    public SearchViewModel(ISearchPageResultsHandler searchHandler)
    {
        _searchHandler = searchHandler;
    }

    public GeneralPageLayout<SearchFilter>? LayoutInstance { get; set; }
    public SearchPageResultsDto? PageResults { get; private set; }

    public async Task OnSearchContextChanged(SearchContext<SearchFilter> searchContext)
    {
        if (searchContext.Query != null)
        {
            await CallSearch(searchContext.Query, searchContext.Filter, searchContext.Page);
        }
    }

    public int GetNumberOfPages() => PageResults?.TotalPages ?? 0;

    private async Task CallSearch(string query, SearchFilter searchFilter = SearchFilter.All, int page = 1)
    {
        PageResults = await _searchHandler.GetSearchPageResultsAsync(searchFilter, query, page);
    }
}