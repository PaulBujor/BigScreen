using BigScreen.Frontend.Components.GeneralPageLayout.Models;
using BigScreen.Frontend.Core.Enums;

namespace BigScreen.Frontend.Pages.GeneralPages.ViewModel;

public interface IBaseGeneralPageViewModel<TSearchResultsDto> where TSearchResultsDto : class
{
    TSearchResultsDto? PageResults { get; }
    Task CallSearch(SortFilter sortFilter = SortFilter.Popularity, int page = 1);
    Task OnSearchContextChanged(SearchContext<SortFilter> searchContext);
}