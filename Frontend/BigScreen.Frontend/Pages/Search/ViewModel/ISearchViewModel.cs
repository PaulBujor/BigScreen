using BigScreen.Core.Models.TMDb;
using BigScreen.Frontend.Components.GeneralPageLayout;
using BigScreen.Frontend.Components.GeneralPageLayout.Models;
using BigScreen.Frontend.Core.Enums;

namespace BigScreen.Frontend.Pages.Search.ViewModel;

public interface ISearchViewModel
{
    SearchPageResultsDto? PageResults { get; }
    GeneralPageLayout<SearchFilter>? LayoutInstance { get; set; }
    Task OnSearchContextChanged(SearchContext<SearchFilter> searchContext);
    int GetNumberOfPages();
}