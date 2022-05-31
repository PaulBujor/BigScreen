using BigScreen.Core.Models.BigScreen;
using BigScreen.Frontend.Client.Handlers.Interfaces;
using BigScreen.Frontend.Client.Security;
using BigScreen.SDK.Client.Abstractions;

namespace BigScreen.Frontend.Client.Handlers;

public class RatingHandler : IRatingHandler
{
    private readonly UserState _userState;
    private readonly IODataClient<RatingDto> _client;

    public RatingHandler(UserState userState, IODataClient<RatingDto> client)
    {
        _userState = userState;
        _client = client;
    }

    public async Task<double> GetBigScreenRating(string mediaId)
    {
        var ratingList = await _client.GetAllAsync($"?$apply=filter(ForMedia eq '{mediaId}')/groupby((ForMedia), aggregate(score with average as score))");
        var rating = ratingList?.FirstOrDefault()?.Score ?? 0;
        return rating;
    }

    public async Task<RatingDto?> GetUserRating(string mediaId)
    {
        if (_userState.User is null)
        {
            return default;
        }
        var ratingList = await _client.GetAllAsync($"?$filter=ForMedia eq '{mediaId}' and ByUser eq '{_userState.User?.Id}'");
        var userRating = ratingList?.FirstOrDefault();
        return userRating;
    }

    public async Task<RatingDto?> AddRating(string mediaId, int rating)
    {
        if (rating == 0)
        {
            return default;
        }
        
        var ratingDto = new RatingDto()
        {
            ForMedia = mediaId,
            Score = rating,
            ByUser = _userState.User?.Id
        };
        return await _client.PostAsync(ratingDto);
    }

    public async Task<RatingDto?> UpdateRating(RatingDto rating)
    {
        if (rating.Score == 0)
        {
            await _client.DeleteAsync(rating.Id);
            return default;
        }

        return await _client.PatchAsync(rating);
    }
}