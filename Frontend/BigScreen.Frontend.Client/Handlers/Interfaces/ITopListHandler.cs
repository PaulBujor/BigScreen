using BigScreen.Core.Models.BigScreen;

namespace BigScreen.Frontend.Client.Handlers.Interfaces;

public interface ITopListHandler
{
    Task<TopListDto?> GetTopListAsync(string topListId);
    Task<TopListDto> CreateTopListAsync(string topListName);
    Task<TopListDto> AddMovieToTopListAsync(string topListId, CachedMediaDto mediaDto);
    Task<TopListDto> RemoveMovieFromTopListAsync(string topListId, string movieId);
    Task DeleteTopListAsync(string topListId);
}