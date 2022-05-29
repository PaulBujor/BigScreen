using BigScreen.Core.Models.TMDb;
using BigScreen.Frontend.Components.MediaDetailsPageLayout.Models;

namespace BigScreen.Frontend.Pages.DetailsPages.TvShow.ViewModel;

public interface ITvShowViewModel
{
    int Id { get; set; }
    TvShowDto? TvShowDetails { get; }
    MediaModel? MediaModel { get; set; }
    Task OnUserScoreChanged(int score);
    Task GetTvShowDetails();
    MediaModel GetMediaModel();
    void OnAddedToTopList();
    string GetFullId();
}