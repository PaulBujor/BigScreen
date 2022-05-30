using BigScreen.Core.Models.BigScreen;
using BigScreen.Frontend.Client.Handlers.Interfaces;
using BigScreen.Frontend.Client.Security;
using BigScreen.Frontend.Core.Exceptions;
using BigScreen.SDK.Client.Abstractions;

namespace BigScreen.Frontend.Client.Handlers;

public class UserHandler : IUserHandler
{
    private readonly IODataClient<UserDto> _client;
    private readonly UserState _userState;

    public UserHandler(UserState userState, IODataClient<UserDto> client)
    {
        _userState = userState;
        _client = client;
    }

    public async Task<UserDto> GetUser(string id)
    {
        try
        {
            var found = await _client.GetByIdAsync(id);
            return found!;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw new UserDoesNotExistException();
        }
    }

    public async Task<UserDto> AddUser(UserDto toAdd)
    {
        return (await _client.PostAsync(toAdd))!;
    }

    public async Task<UserDto?> PatchUserAsync(UserDto userStateUser)
    {
        return await _client.PatchAsync(userStateUser);
    }

    public async Task FollowUser(CachedUserDto userToFollow)
    {
        var existingUser = _userState.User;
        if (existingUser?.Following == null)
            existingUser!.Following = new List<CachedUserDto>();

        existingUser.Following.Add(userToFollow);
        _userState.User = await PatchUserAsync(existingUser);
    }

    public async Task UnfollowUser(CachedUserDto userToFollow)
    {
        var existingUser = _userState.User;
        existingUser?.Following?.Remove(userToFollow);
        _userState.User = await PatchUserAsync(existingUser!);
    }
}