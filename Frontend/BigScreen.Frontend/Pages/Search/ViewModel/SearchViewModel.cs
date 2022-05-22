using BigScreen.Frontend.Client.Handlers.Interfaces;
using BigScreen.Frontend.Core.Enums;

namespace BigScreen.Frontend.Pages.Search.ViewModel;

public class SearchViewModel : ISearchViewModel
{
    private readonly ISearchPageResultsHandler _searchHandler;
    private string _searchQuery;

    public SearchViewModel(ISearchPageResultsHandler searchHandler)
    {
        _searchHandler = searchHandler;
    }

    public string SearchFilterText => "Search by";
    public string SearchTextFieldText => "Search";
    public SearchFilter SearchFilter { get; set; } = SearchFilter.All;

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
        var results = await _searchHandler.GetSearchPageResultsByType(SearchFilter, query);
        Console.WriteLine("works");
    }
}