using BigScreen.Core.Models.TMDb;
using BigScreen.Frontend.Client.Handlers.Interfaces;
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

    public int CurrentPage
    {
        get => _currentPage;
        set
        {
            _currentPage = value;
            if (!string.IsNullOrEmpty(SearchQuery))
            {
                CallSearch(SearchQuery, value);
            }
        }
    }
    public Action RefreshView { get; set; } = null!;
    public string SearchFilterText => "Search in";
    public string SearchTextFieldText => "Search";
    public SearchPageResultsDto? PageResults { get; private set; }

    public SearchFilter SearchFilter
    {
        get => _searchFilter;
        set
        {
            _searchFilter = value;

            if (!string.IsNullOrEmpty(SearchQuery))
            {
                CallSearch(SearchQuery);
                ResetCurrentPage();
            }
        }
    }

    public string SearchQuery
    {
        get => _searchQuery;
        set
        {
            _searchQuery = value;
            if (!string.IsNullOrEmpty(value))
            {
                CallSearch(value);
                ResetCurrentPage();
            }
        }
    }
    
    public void DisposeViewModel()
    {
        _currentPage = 1;
        _searchFilter = SearchFilter.All;
        _searchQuery = string.Empty;
        PageResults = null;
    }

    private async Task CallSearch(string query, int page = 1)
    {
        PageResults = await _searchHandler.GetSearchPageResults(SearchFilter, query, page);
        RefreshView.Invoke();
    }

    private void ResetCurrentPage()
    {
        _currentPage = 1;
    }
    
}