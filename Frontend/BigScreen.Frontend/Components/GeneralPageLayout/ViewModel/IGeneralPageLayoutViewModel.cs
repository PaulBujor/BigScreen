using BigScreen.Frontend.Components.GeneralPageLayout.Models;
using Microsoft.AspNetCore.Components;

namespace BigScreen.Frontend.Components.GeneralPageLayout.ViewModel;

public interface IGeneralPageLayoutViewModel<TFilter>
{
    TFilter CurrentFilter { get; set; }
    int CurrentPage { get; set; }
    EventCallback<SearchContext<TFilter>> SearchContextChanged { get; set; }
    bool HasSearch { get; set; }
    string SearchQuery { get; set; }
    int GetPaginationCount(int numberOfPages);
}