using BigScreen.Core.Models.TMDb;
using BigScreen.Frontend.Components.GeneralPageLayout.Models;
using BigScreen.Frontend.Core.Enums;

namespace BigScreen.Frontend.Pages.GeneralPages.Movies.ViewModel;

public interface IMoviesViewModel
{
    MoviesGeneralSearchResultsDto? Results { get; }
    Task CallSearch(SortFilter sortFilter = SortFilter.Popularity, int page = 1);
    Task OnSearchContextChanged(SearchContext searchContext);
}