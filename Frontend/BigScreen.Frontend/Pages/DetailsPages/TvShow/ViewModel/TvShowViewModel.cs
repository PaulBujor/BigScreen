using BigScreen.Core.Models.BigScreen;
using BigScreen.Core.Models.TMDb;
using BigScreen.Frontend.Client.Handlers.Interfaces;
using BigScreen.Frontend.Components.MediaDetailsPageLayout.Models;
using BigScreen.Frontend.Components.SelectTopList;
using MudBlazor;

namespace BigScreen.Frontend.Pages.DetailsPages.TvShow.ViewModel;

public class TvShowViewModel : ITvShowViewModel
{
    private readonly IDialogService _dialogService;
    private readonly IDetailsPageHandler<TvShowDto> _mediaHandler;

    public TvShowViewModel(IDetailsPageHandler<TvShowDto> mediaHandler, IDialogService dialogService)
    {
        _mediaHandler = mediaHandler;
        _dialogService = dialogService;
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

    public async Task GetTvShowDetails() => TvShowDetails = await _mediaHandler.GetMediaDetailsAsync(Id);

    public MediaModel GetMediaModel()
    {
        var mediaModel = MediaModel.FromTvShowDto(TvShowDetails);
        return mediaModel ?? new MediaModel();
    }

    public void OnAddedToTopList()
    {
        var parameters = new DialogParameters();
        parameters.Add(nameof(MovieDto), new CachedMovieDto
        {
            Id = GetFullId(),
            ImageUrl = TvShowDetails?.ImageUrlSmall,
            Name = MediaModel.Title
        });
        _dialogService.Show<SelectTopList>("Select a Top List", parameters);
    }

    public string GetFullId() => $"tvshow-{Id}";
}