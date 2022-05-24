using BigScreen.Frontend.Components.GeneralPageLayout.Models;
using BigScreen.Frontend.Core.Enums;
using Microsoft.AspNetCore.Components;

namespace BigScreen.Frontend.Components.GeneralPageLayout.ViewModel;

public interface IGeneralPageLayoutViewModel
{
    SortFilter[] SortFilterOptions { get; set; }
    SortFilter CurrentSortFilter { get; set; }
    int CurrentPage { get; set; }
    EventCallback<SearchContext> SearchContextChanged { get; set; }
    int GetPaginationCount(int numberOfPages);
    bool HasSearch { get; set; }
    string SearchQuery { get; set; }
}