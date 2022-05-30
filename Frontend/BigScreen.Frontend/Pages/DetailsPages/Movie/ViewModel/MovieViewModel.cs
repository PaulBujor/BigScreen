using BigScreen.Core.Models.BigScreen;
using BigScreen.Core.Models.TMDb;
using BigScreen.Frontend.Client.Handlers.Interfaces;
using BigScreen.Frontend.Components.MediaDetailsPageLayout.Models;
using BigScreen.Frontend.Components.SelectTopList;
using MudBlazor;

namespace BigScreen.Frontend.Pages.DetailsPages.Movie.ViewModel;

public class MovieViewModel : IMovieViewModel
{
    private readonly IDialogService _dialogService;
    private readonly IDetailsPageHandler<MovieDto> _mediaHandler;

    public MovieViewModel(IDetailsPageHandler<MovieDto> mediaHandler, IDialogService dialogService)
    {
        _mediaHandler = mediaHandler;
        _dialogService = dialogService;
    }

    public int Id { get; set; }
    public MovieDto? MovieDetails { get; private set; }
    public MediaModel MediaModel { get; set; } = null!;

    public Task OnUserScoreChanged(int score)
    {
        MediaModel.UserScore = score;
        // todo call backend client to update user score and get new BigScreen score
        return Task.CompletedTask;
    }

    public async Task GetMovieDetails()
    {
        MovieDetails = await _mediaHandler.GetMediaDetails(Id);
    }

    public MediaModel GetMediaModel()
    {
        var mediaModel = MediaModel.FromMovieDto(MovieDetails);
        return mediaModel ?? new MediaModel();
    }

    public void OnAddedToTopList()
    {
        var parameters = new DialogParameters();
        parameters.Add(nameof(MovieDto), new CachedMovieDto
        {
            Id = GetFullId(),
            ImageUrl = MovieDetails?.ImageUrlSmall,
            Name = MediaModel.Title
        });
        _dialogService.Show<SelectTopList>("Select a Top List", parameters);
    }

    public string GetFullId()
    {
        return $"movie-{Id}";
    }
}