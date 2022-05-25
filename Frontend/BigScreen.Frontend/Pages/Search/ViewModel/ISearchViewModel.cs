using BigScreen.Core.Models.TMDb;
using BigScreen.Frontend.Components.GeneralPageLayout;
using BigScreen.Frontend.Components.GeneralPageLayout.Models;
using BigScreen.Frontend.Core.Enums;

namespace BigScreen.Frontend.Pages.Search.ViewModel;

public interface ISearchViewModel
{
    string SearchFilterText { get; }
    string SearchTextFieldText { get; }
    SearchPageResultsDto? PageResults { get; }
    Action RefreshView { get; set; }
    GeneralPageLayout<SearchFilter> LayoutInstance { get; set; }
    void DisposeViewModel();
    Task OnSearchContextChanged(SearchContext<SearchFilter> searchContext);
    int GetNumberOfPages();
}