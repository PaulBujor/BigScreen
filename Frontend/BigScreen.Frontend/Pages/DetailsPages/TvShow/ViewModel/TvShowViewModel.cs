using BigScreen.Core.Models.TMDb;
using BigScreen.Frontend.Client.Handlers.Interfaces;
using BigScreen.Frontend.Components.MediaDetailsPageLayout.Models;

namespace BigScreen.Frontend.Pages.DetailsPages.TvShow.ViewModel;

public class TvShowViewModel : ITvShowViewModel
{
    private readonly IDetailsPageHandler<TvShowDto> _mediaHandler;

    public TvShowViewModel(IDetailsPageHandler<TvShowDto> mediaHandler)
    {
        _mediaHandler = mediaHandler;
    }

    public int Id { get; set; }
    public TvShowDto? TvShowDetails { get; private set; }
    public MediaModel MediaModel { get; set; } = null!;

    public Task OnUserScoreChanged(int score)
    {
        MediaModel.UserScore = score;
        // todo call backend client to update user score and get new BigScreen score
        return Task.CompletedTask;
    }

    public async Task GetTvShowDetails() => TvShowDetails = await _mediaHandler.GetMediaDetails(Id);

    public MediaModel GetMediaModel()
    {
        var mediaModel = MediaModel.FromTvShowDto(TvShowDetails);
        return mediaModel ?? new MediaModel();
    }

    public void OnAddedToTopList()
    {
        Console.WriteLine("Added to top list clicked - tv show page");
    }

    public string GetFullId() => $"tvshow-{Id}";
}