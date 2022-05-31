using BigScreen.Core.Models.BigScreen;

namespace BigScreen.Frontend.Client.Handlers.Interfaces;

public interface ITopListHandler
{
    Task<TopListDto?> GetTopListAsync(string topListId);
    Task<TopListDto> CreateTopListAsync(string topListName);
    Task<TopListDto> AddMediaToTopListAsync(string topListId, CachedMediaDto mediaDto);
    Task<TopListDto> RemoveMediaFromTopListAsync(string topListId, string mediaId);
    Task DeleteTopListAsync(string topListId);
}