using BigScreen.Core.Models.BigScreen;

namespace BigScreen.Frontend.Client.Handlers.Interfaces;

public interface IRatingHandler
{
    Task<double> GetBigScreenRating(string mediaId);
    Task<RatingDto?> GetUserRating(string mediaId);
    Task<RatingDto?> AddRating(string mediaId, int rating);
    Task<RatingDto?> UpdateRating(RatingDto rating);
}