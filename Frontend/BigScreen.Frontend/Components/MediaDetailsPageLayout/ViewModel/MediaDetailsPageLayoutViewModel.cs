using BigScreen.Frontend.Components.MediaDetailsPageLayout.Models;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace BigScreen.Frontend.Components.MediaDetailsPageLayout.ViewModel;

public class MediaDetailsPageLayoutViewModel : IMediaDetailsPageLayoutViewModel
{
    public MediaModel MediaModel { get; set; } = null!;
    public EventCallback<int> UserScoreChanged { get; set; }

    public (string Icon, string Text) GetTopListButtonInfo() => MediaModel.AddedToToplist
        ? (Icons.Filled.Check, "Added to Top List")
        : (Icons.Filled.Add, "Add to Top List");

    public (string Title, string Year) GetHeader()
    {
        var title = MediaModel.Title;
        var year = string.Empty;

        if (MediaModel.ReleaseDate is not null)
        {
            year = $"({MediaModel.ReleaseDate.Value.Year})";
        }

        return (title, year);
    }

    public string GetReleaseDate() => MediaModel.ReleaseDate is not null
        ? MediaModel.ReleaseDate.Value.ToString("dd/MM/yyyy")
        : string.Empty;

    public string GetGenres() => MediaModel.Genres is not null ? string.Join(", ", MediaModel.Genres) : string.Empty;

    public string GetDuration() => MediaModel.Duration.ToString("hh") + "h " + MediaModel.Duration.ToString("mm") + "m";
    public string GetTagline() => MediaModel.Tagline ?? string.Empty;
    public async Task OnUserScoreChanged(int score)
    {
        await UserScoreChanged.InvokeAsync(score);
    }
}