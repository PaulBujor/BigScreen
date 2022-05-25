using BigScreen.Core.Models.TMDb;
using BigScreen.Frontend.Client.Handlers.Interfaces;
using BigScreen.Frontend.Components.GeneralPageLayout;
using BigScreen.Frontend.Components.GeneralPageLayout.Models;
using BigScreen.Frontend.Core.Enums;

namespace BigScreen.Frontend.Pages.Search.ViewModel;

public class SearchViewModel : ISearchViewModel
{
    private readonly ISearchPageResultsHandler _searchHandler;
    private int _currentPage = 1;
    private SearchFilter _searchFilter = SearchFilter.All;
    private string _searchQuery = string.Empty;

    public SearchViewModel(ISearchPageResultsHandler searchHandler)
    {
        _searchHandler = searchHandler;
    }


    public Action RefreshView { get; set; } = null!;
    public GeneralPageLayout<SearchFilter> LayoutInstance { get; set; }
    public string SearchFilterText => "Search in";
    public string SearchTextFieldText => "Search";
    public SearchPageResultsDto? PageResults { get; private set; }

    public void DisposeViewModel()
    {
        _currentPage = 1;
        _searchFilter = SearchFilter.All;
        _searchQuery = string.Empty;
        PageResults = null;
    }

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
        PageResults = await _searchHandler.GetSearchPageResults(searchFilter, query, page);
    }
}