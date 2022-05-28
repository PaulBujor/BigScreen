using BigScreen.Core.Models.TMDb;
using BigScreen.Frontend.Client.Handlers.Interfaces;
using BigScreen.Frontend.Components.MediaDetailsPageLayout.Models;

namespace BigScreen.Frontend.Pages.DetailsPages.Movie.ViewModel;

public class MovieViewModel : IMovieViewModel
{
    private readonly IDetailsPageHandler<MovieDto> _movieHandler;

    public MovieViewModel(IDetailsPageHandler<MovieDto> movieHandler)
    {
        _movieHandler = movieHandler;
    }

    public int Id { get; set; }
    public MovieDto? MovieDetails { get; private set; }
    public async Task GetMovieDetails() => MovieDetails = await _movieHandler.GetMediaDetails(Id);

    public MediaModel GetMediaModel()
    {
        var mediaModel = MediaModel.FromMovieDto(MovieDetails);
        return mediaModel ?? new MediaModel();
    }
}