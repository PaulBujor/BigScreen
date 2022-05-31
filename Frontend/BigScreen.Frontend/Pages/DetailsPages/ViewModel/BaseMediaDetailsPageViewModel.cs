using BigScreen.Core.Models.BigScreen;
using BigScreen.Core.Models.TMDb;
using BigScreen.Core.Models.TMDb.Base;
using BigScreen.Frontend.Client.Handlers.Interfaces;
using BigScreen.Frontend.Components.MediaDetailsPageLayout.Models;
using BigScreen.Frontend.Components.SelectTopList;
using BigScreen.Frontend.Core;
using MudBlazor;

namespace BigScreen.Frontend.Pages.DetailsPages.ViewModel;

public abstract class BaseMediaDetailsPageViewModel<TDto> : IBaseMediaDetailsPageViewModel<TDto> where TDto : BaseMediaDetailsDto
{
    private readonly IDetailsPageHandler<TDto> _mediaHandler;
    private readonly IDialogService _dialogService;
    private readonly IRatingHandler _ratingHandler;

    protected BaseMediaDetailsPageViewModel(IDetailsPageHandler<TDto> mediaHandler, IDialogService dialogService,
        IRatingHandler ratingHandler)
    {
        _mediaHandler = mediaHandler;
        _dialogService = dialogService;
        _ratingHandler = ratingHandler;
    }

    public int Id { get; set; }
    public RatingDto? UserScore { get; private set; }
    public double BigScreenScore { get; private set; }
    public TDto? MediaDetails { get; private set; }
    public MediaModel MediaModel { get; set; } = null!;
    public async Task OnUserScoreChanged(int score)
    {
        if (string.IsNullOrEmpty(UserScore?.ETag))
        {
            UserScore = await _ratingHandler.AddRating(GetFullId(), score);
        }
        else
        {
            UserScore.Score = score;
            UserScore = await _ratingHandler.UpdateRating(UserScore);
        }

        await GetBigScreenScore();
        UpdateScores();
    }
    
    private async Task GetBigScreenScore()
    {
        BigScreenScore = await _ratingHandler.GetBigScreenRating(GetFullId());
    }

    private void UpdateScores()
    {
        MediaModel.BigScreenScore = BigScreenScore;
        MediaModel.UserScore = UserScore;
    }

    public async Task GetMediaDetails()
    {
        MediaDetails = await _mediaHandler.GetMediaDetailsAsync(Id);
        var mediaModel = MediaModel.FromMediaDto(MediaDetails) ?? new MediaModel();
        UserScore = await _ratingHandler.GetUserRating(GetFullId());
        await GetBigScreenScore();
        mediaModel.UserScore = UserScore;
        mediaModel.BigScreenScore = BigScreenScore;
        MediaModel = mediaModel;
    }

    public void OnAddedToTopList()
    {
        var parameters = new DialogParameters();
        parameters.Add("Media", new CachedMediaDto
        {
            Id = GetFullId(),
            ImageUrl = MediaDetails?.ImageUrlSmall,
            Name = MediaModel.Title
        });
        _dialogService.Show<SelectTopList>("Select a Top List", parameters);
    }
    public abstract string GetFullId();
}