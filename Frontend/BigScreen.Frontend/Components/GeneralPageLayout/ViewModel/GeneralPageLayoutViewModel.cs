using BigScreen.Frontend.Components.GeneralPageLayout.Models;
using Microsoft.AspNetCore.Components;

namespace BigScreen.Frontend.Components.GeneralPageLayout.ViewModel;

public class GeneralPageLayoutViewModel<TFilter> : IGeneralPageLayoutViewModel<TFilter>
{
    private TFilter _currentFilter = default!;
    private int _currentPage = 1;
    private string _searchQuery = string.Empty;

    public bool HasSearch { get; set; }

    public string SearchQuery
    {
        get => _searchQuery;
        set
        {
            _searchQuery = value;
            if (!string.IsNullOrEmpty(value))
            {
                ResetCurrentPage();
                InvokeSearchContextChanged();
            }
        }
    }

    public TFilter CurrentFilter
    {
        get => _currentFilter;
        set
        {
            _currentFilter = value;
            ResetCurrentPage();
            InvokeSearchContextChanged();
        }
    }

    public int CurrentPage
    {
        get => _currentPage;
        set
        {
            _currentPage = value;
            InvokeSearchContextChanged();
        }
    }

    public EventCallback<SearchContext<TFilter>> SearchContextChanged { get; set; }

    public int GetPaginationCount(int numberOfPages) => numberOfPages > 500 ? 500 : numberOfPages;

    private void ResetCurrentPage()
    {
        _currentPage = 1;
    }

    private async Task InvokeSearchContextChanged()
    {
        if (HasSearch)
        {
            await SearchContextChanged.InvokeAsync(new SearchContext<TFilter>(_currentPage, _currentFilter,
                _searchQuery));
        }
        else
        {
            await SearchContextChanged.InvokeAsync(new SearchContext<TFilter>(_currentPage, _currentFilter));
        }
    }
}