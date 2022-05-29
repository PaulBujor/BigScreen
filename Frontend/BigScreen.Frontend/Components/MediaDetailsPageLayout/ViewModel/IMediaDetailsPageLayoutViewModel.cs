using BigScreen.Frontend.Components.MediaDetailsPageLayout.Models;
using Microsoft.AspNetCore.Components;

namespace BigScreen.Frontend.Components.MediaDetailsPageLayout.ViewModel;

public interface IMediaDetailsPageLayoutViewModel
{
    MediaModel MediaModel { get; set; }
    EventCallback<int> UserScoreChanged { get; set; }
    (string Title, string Year) GetHeader();
    string GetReleaseDate();
    string GetGenres();
    string GetDuration();
    string GetTagline();
    Task OnUserScoreChanged(int args);
}