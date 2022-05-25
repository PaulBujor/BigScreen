using BigScreen.Frontend.Components.GeneralPageLayout.Models;
using Microsoft.AspNetCore.Components;

namespace BigScreen.Frontend.Components.GeneralPageLayout.ViewModel;

public interface IGeneralPageLayoutViewModel<TFilter>
{
    EventCallback<SearchContext<TFilter>> SearchContextChanged { get; set; }
    bool HasSearch { get; set; }
    string SearchQuery { get; set; }
    int GetPaginationCount(int numberOfPages);
    Task OnFilterChanged(TFilter filter);
    Task OnPageChanged(int page);
    TFilter GetCurrentFilter();
}