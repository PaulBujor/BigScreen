using BigScreen.Core.Models.TMDb;
using BigScreen.Frontend.Core.Enums;

namespace BigScreen.Frontend.Pages.GeneralPages.Movies.ViewModel;

public interface IMoviesViewModel
{
    MoviesGeneralSearchResultsDto? Results { get;}
    Task CallSearch(SortFilter sortFilter = SortFilter.Popularity);
}