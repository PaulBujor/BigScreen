using BigScreen.Frontend.Components.GeneralPageLayout.Models;
using Microsoft.AspNetCore.Components;

namespace BigScreen.Frontend.Components.GeneralPageLayout.ViewModel;

public interface IGeneralPageLayoutViewModel<TFilter>
{
    EventCallback<SearchContext<TFilter>> SearchContextChanged { get; set; }
    bool HasSearch { get; set; }
    string SearchQuery { get; set; }
    TFilter CurrentFilter { get; }
    int CurrentPage { get; }
    int GetPaginationCount(int numberOfPages);
    Task OnFilterChanged(TFilter filter);
    Task OnPageChanged(int page);
}