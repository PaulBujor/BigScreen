using BigScreen.Core.Models.BigScreen;
using BigScreen.Core.Models.TMDb;
using BigScreen.Frontend.Client.Handlers.Interfaces;
using BigScreen.Frontend.Components.MediaDetailsPageLayout.Models;
using BigScreen.Frontend.Components.SelectTopList;
using BigScreen.Frontend.Pages.DetailsPages.ViewModel;
using MudBlazor;

namespace BigScreen.Frontend.Pages.DetailsPages.Movie.ViewModel;

public class MovieViewModel : BaseMediaDetailsPageViewModel<MovieDto>, IMovieViewModel
{
    public MovieViewModel(IDetailsPageHandler<MovieDto> mediaHandler, IDialogService dialogService, IRatingHandler ratingHandler) : base(mediaHandler,dialogService, ratingHandler)
    {
    }
    
    public override string GetFullId() => $"movie-{Id}";
}