using BigScreen.Frontend.Components.GeneralPageLayout.Models;
using BigScreen.Frontend.Core.Enums;
using Microsoft.AspNetCore.Components;

namespace BigScreen.Frontend.Components.GeneralPageLayout.ViewModel;

public class GeneralPageLayoutViewModel : IGeneralPageLayoutViewModel
{
    private int _currentPage = 1;
    private SortFilter _currentSortFilter = SortFilter.Popularity;
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

    public SortFilter[] SortFilterOptions { get; set; } = null!;


    public SortFilter CurrentSortFilter
    {
        get => _currentSortFilter;
        set
        {
            _currentSortFilter = value;
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

    public EventCallback<SearchContext> SearchContextChanged { get; set; }

    public int GetPaginationCount(int numberOfPages) => numberOfPages > 1000 ? 1000 : numberOfPages;

    private void ResetCurrentPage()
    {
        _currentPage = 1;
    }

    private async Task InvokeSearchContextChanged()
    {
        if (HasSearch)
        {
            await SearchContextChanged.InvokeAsync(new SearchContext(_currentPage, _currentSortFilter, _searchQuery));
        }
        else
        {
            await SearchContextChanged.InvokeAsync(new SearchContext(_currentPage, _currentSortFilter));
        }
    }
}