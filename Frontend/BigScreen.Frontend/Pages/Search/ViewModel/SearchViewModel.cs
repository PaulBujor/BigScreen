using BigScreen.Core.Models.TMDb;
using BigScreen.Frontend.Client.Handlers.Interfaces;
using BigScreen.Frontend.Core.Enums;

namespace BigScreen.Frontend.Pages.Search.ViewModel;

public class SearchViewModel : ISearchViewModel
{
    private readonly ISearchPageResultsHandler _searchHandler;
    private SearchFilter _searchFilter = SearchFilter.All;
    private string _searchQuery = null!;

    public SearchViewModel(ISearchPageResultsHandler searchHandler)
    {
        _searchHandler = searchHandler;
    }

    public Action RefreshView { get; set; } = null!;

    public string SearchFilterText => "Search in";
    public string SearchTextFieldText => "Search";

    public SearchFilter SearchFilter
    {
        get => _searchFilter;
        set
        {
            _searchFilter = value;

            if (!string.IsNullOrEmpty(SearchQuery))
            {
                CallSearch(SearchQuery);
            }
        }
    }

    public SearchPageResultsDto? PageResults { get; set; }

    public string SearchQuery
    {
        get => _searchQuery;
        set
        {
            _searchQuery = value;
            if (!string.IsNullOrEmpty(value))
            {
                CallSearch(value);
            }
        }
    }

    public async Task CallSearch(string query)
    {
        PageResults = await _searchHandler.GetSearchPageResultsByType(SearchFilter, query);
        RefreshView.Invoke();
    }
}