using BigScreen.Core.Models.TMDb;
using BigScreen.Frontend.Components.MediaDetailsPageLayout.Models;

namespace BigScreen.Frontend.Pages.DetailsPages.Movie.ViewModel;

public interface IMovieViewModel
{
    int Id { get; set; }
    MovieDto? MovieDetails { get; }
    MediaModel? MediaModel { get; set; }
    Task OnUserScoreChanged(int score);
    Task GetMovieDetails();
    MediaModel GetMediaModel();
    void OnAddedToTopList();
    string GetFullId();
}