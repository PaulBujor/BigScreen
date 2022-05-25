using BigScreen.Core.Models.TMDb;
using BigScreen.Frontend.Client.Handlers.Interfaces;
using BigScreen.Frontend.Pages.GeneralPages.ViewModel;

namespace BigScreen.Frontend.Pages.GeneralPages.TvShows.ViewModel;

public class TvShowsViewModel : BaseGeneralPageViewModel<TvShowsSearchResultsDto>, ITvShowsViewModel
{
    public TvShowsViewModel(IGeneralSearchPageResultsHandler<TvShowsSearchResultsDto> handler) : base(handler)
    {
    }
}