using BigScreen.Core.Models.BigScreen;

namespace BigScreen.Frontend.Client.Handlers.Interfaces;

public interface ITopListHandler
{
    Task<TopListDto?> GetTopListAsync(string topListId);
    Task<TopListDto> CreateTopListAsync(string topListName);
}