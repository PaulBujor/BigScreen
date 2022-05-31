using BigScreen.Core.Models.BigScreen;
using BigScreen.Core.Models.TMDb;
using BigScreen.Frontend.Client.Handlers.Interfaces;
using BigScreen.Frontend.Components.MediaDetailsPageLayout.Models;
using BigScreen.Frontend.Components.SelectTopList;
using BigScreen.Frontend.Pages.DetailsPages.ViewModel;
using MudBlazor;

namespace BigScreen.Frontend.Pages.DetailsPages.TvShow.ViewModel;

public class TvShowViewModel : BaseMediaDetailsPageViewModel<TvShowDto>, ITvShowViewModel
{
    public TvShowViewModel(IDetailsPageHandler<TvShowDto> mediaHandler, IRatingHandler ratingHandler,
        IDialogService dialogService) : base(mediaHandler, dialogService, ratingHandler)
    {
    }

    public override string GetFullId() => $"tvshow-{Id}";
}