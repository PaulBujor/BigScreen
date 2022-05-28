using BigScreen.Core.Models.TMDb;
using BigScreen.Frontend.Components.MediaDetailsPageLayout.Models;

namespace BigScreen.Frontend.Pages.DetailsPages.Movie.ViewModel;

public interface IMovieViewModel
{
    int Id { get; set; }
    MovieDto? MovieDetails { get; }
    Task GetMovieDetails();
    MediaModel GetMediaModel();
}