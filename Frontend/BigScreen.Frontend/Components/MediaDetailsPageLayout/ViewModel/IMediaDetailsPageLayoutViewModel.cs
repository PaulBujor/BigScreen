using BigScreen.Frontend.Components.MediaDetailsPageLayout.Models;

namespace BigScreen.Frontend.Components.MediaDetailsPageLayout.ViewModel;

public interface IMediaDetailsPageLayoutViewModel
{
    MediaModel MediaModel { get; set; }
    (string Icon, string Text) GetTopListButtonInfo();

    (string Title, string Year) GetHeader();
    string GetReleaseDate();
    string GetGenres();
    string GetDuration();
    string GetTagline();

}