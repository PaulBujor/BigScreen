using BigScreen.Frontend.Components.GeneralPageLayout.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace BigScreen.Frontend.Components.GeneralPageLayout.ViewModel;

public class GeneralPageLayoutViewModel<TFilter> : IGeneralPageLayoutViewModel<TFilter>
{
    private readonly IJSRuntime _jsRuntime;
    private string _searchQuery = string.Empty;

    public GeneralPageLayoutViewModel(IJSRuntime jsRuntime)
    {
        _jsRuntime = jsRuntime;
    }

    public TFilter CurrentFilter { get; private set; } = default!;
    public int CurrentPage { get; private set; } = 1;

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
        CurrentFilter = filter;
        ResetCurrentPage();
        await InvokeSearchContextChanged();
    }

    public async Task OnPageChanged(int page)
    {
        CurrentPage = page;
        await InvokeSearchContextChanged();
        await _jsRuntime.InvokeVoidAsync("scrollToTop");
    }

    private void ResetCurrentPage()
    {
        CurrentPage = 1;
    }

    private async Task InvokeSearchContextChanged()
    {
        if (HasSearch)
        {
            await SearchContextChanged.InvokeAsync(new SearchContext<TFilter>(CurrentPage, CurrentFilter,
                _searchQuery));
        }
        else
        {
            await SearchContextChanged.InvokeAsync(new SearchContext<TFilter>(CurrentPage, CurrentFilter));
        }
    }
}