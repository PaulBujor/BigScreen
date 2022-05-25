using BigScreen.Frontend.Components.GeneralPageLayout.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace BigScreen.Frontend.Components.GeneralPageLayout.ViewModel;

public class GeneralPageLayoutViewModel<TFilter> : IGeneralPageLayoutViewModel<TFilter>
{
    private readonly IJSRuntime _jsRuntime;
    private TFilter _currentFilter = default!;
    private int _currentPage = 1;
    private string _searchQuery = string.Empty;

    public GeneralPageLayoutViewModel(IJSRuntime jsRuntime)
    {
        _jsRuntime = jsRuntime;
    }

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

    public EventCallback<SearchContext<TFilter>> SearchContextChanged { get; set; }

    public int GetPaginationCount(int numberOfPages) => numberOfPages > 500 ? 500 : numberOfPages;

    public async Task OnFilterChanged(TFilter filter)
    {
        _currentFilter = filter;
        ResetCurrentPage();
        await InvokeSearchContextChanged();
    }

    public async Task OnPageChanged(int page)
    {
        _currentPage = page;
        await InvokeSearchContextChanged();
        await _jsRuntime.InvokeVoidAsync("scrollToTop");
    }

    public TFilter GetCurrentFilter() => _currentFilter;

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