using BigScreen.Core.Models.BigScreen;
using BigScreen.Core.Models.TMDb;
using BigScreen.Core.Models.TMDb.Base;
using BigScreen.Frontend.Components.MediaDetailsPageLayout.Models;
using BigScreen.Frontend.Core;

namespace BigScreen.Frontend.Pages.DetailsPages.ViewModel;

public interface IBaseMediaDetailsPageViewModel<TDto> where TDto : BaseMediaDetailsDto
{
    int Id { get; set; }
    RatingDto? UserScore { get; }
    double BigScreenScore { get; }
    TDto? MediaDetails { get; }
    MediaModel? MediaModel { get; set; }
    Task OnUserScoreChanged(int score);
    Task GetMediaDetails();
    void OnAddedToTopList();
    string GetFullId();
}