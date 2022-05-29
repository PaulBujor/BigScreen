using BigScreen.Core.Models.TMDb;
using BigScreen.Frontend.Client.Handlers.Interfaces;
using BigScreen.Frontend.Components.MediaDetailsPageLayout.Models;

namespace BigScreen.Frontend.Pages.DetailsPages.Movie.ViewModel;

public class MovieViewModel : IMovieViewModel
{
    private readonly IDetailsPageHandler<MovieDto> _mediaHandler;

    public MovieViewModel(IDetailsPageHandler<MovieDto> mediaHandler)
    {
        _mediaHandler = mediaHandler;
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

    public async Task GetMovieDetails() => MovieDetails = await _mediaHandler.GetMediaDetails(Id);

    public MediaModel GetMediaModel()
    {
        var mediaModel = MediaModel.FromMovieDto(MovieDetails);
        return mediaModel ?? new MediaModel();
    }

    public void OnAddedToTopList()
    {
        Console.WriteLine("Added to top list clicked - movie page");
    }

    public string GetFullId() => $"movie-{Id}";
}