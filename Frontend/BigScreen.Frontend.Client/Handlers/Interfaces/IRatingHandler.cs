using BigScreen.Core.Models.BigScreen;

namespace BigScreen.Frontend.Client.Handlers.Interfaces;

public interface IRatingHandler
{
    Task<double> GetBigScreenRating(string movieId);
    Task<RatingDto?> GetUserRating(string movieId);
    Task<RatingDto?> AddRating(string movieId, int rating);
    Task<RatingDto?> UpdateRating(RatingDto rating);
}