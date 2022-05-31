using BigScreen.Core.Models.BigScreen;
using BigScreen.Frontend.Client.Handlers.Interfaces;
using BigScreen.Frontend.Client.Security;
using BigScreen.SDK.Client.Abstractions;

namespace BigScreen.Frontend.Client.Handlers;

public class TopListHandler : ITopListHandler
{
    private readonly IODataClient<TopListDto> _client;
    private readonly IODataClient<UserDto> _userClient;
    private readonly UserState _userState;

    public TopListHandler(UserState userState, IODataClient<TopListDto> client, IODataClient<UserDto> userClient)
    {
        _userState = userState;
        _client = client;
        _userClient = userClient;
    }

    public async Task<TopListDto?> GetTopListAsync(string topListId)
    {
        return await _client.GetByIdAsync(topListId);
    }

    public async Task<TopListDto> CreateTopListAsync(string topListName)
    {
        if (_userState.User == null) throw new InvalidOperationException();

        var topList = new TopListDto
        {
            Title = topListName,
            Owner = _userState.User.GetCachedVersion(),
            MediaItems = new List<CachedMediaDto>()
        };

        topList = await _client.PostAsync(topList);

        if (_userState.User.SavedTopLists == null)
            _userState.User.SavedTopLists = new HashSet<CachedTopListDto>();

        _userState.User.SavedTopLists.Add(topList?.GetCachedVersion()!);
        _userState.User = await _userClient.PatchAsync(_userState.User);

        return topList!;
    }

    public async Task<TopListDto> AddMediaToTopListAsync(string topListId, CachedMediaDto mediaDto)
    {
        var topList = await GetTopListAsync(topListId);
        if (topList == null) throw new InvalidOperationException();

        topList.MediaItems ??= new List<CachedMediaDto>();

        if (!topList.MediaItems.Contains(mediaDto))
            topList.MediaItems.Add(mediaDto);

        return (await _client.PatchAsync(topList))!;
    }

    public async Task<TopListDto> RemoveMediaFromTopListAsync(string topListId, string mediaId)
    {
        var topList = await GetTopListAsync(topListId);
        if (topList == null) throw new InvalidOperationException();

        var idDto = new CachedMediaDto
        {
            Id = mediaId
        };

        topList.MediaItems?.Remove(idDto);

        return (await _client.PatchAsync(topList))!;
    }

    public async Task DeleteTopListAsync(string topListId)
    {
        var topList = new TopListDto {Id = topListId};
        await _client.DeleteAsync(topListId);
        _userState.User?.SavedTopLists?.Remove(topList.GetCachedVersion());
        _userState.User = await _userClient.PatchAsync(_userState.User!);
    }
}