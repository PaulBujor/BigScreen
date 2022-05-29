using BigScreen.Core.Models.BigScreen;
using BigScreen.Frontend.Client.Handlers.Interfaces;
using BigScreen.Frontend.Client.Security;
using BigScreen.Frontend.Core.Exceptions;

namespace BigScreen.Frontend.Client.Handlers;

public class UserHandler : IUserHandler
{
    private readonly IList<UserDto> _dummyUsers = new List<UserDto>
    {
        new()
        {
            Id = "1",
            Username = "Username1",
            SavedTopLists = new HashSet<CachedTopListDto>
            {
                new()
                {
                    Id = "1",
                    Title = "My cached Toplist 1"
                },
                new()
                {
                    Id = "2",
                    Title = "My cached Toplist 2"
                },
                new()
                {
                    Id = "3",
                    Title = "My cached Toplist 3"
                },
                new()
                {
                    Id = "4",
                    Title = "My cached Toplist 4"
                }
            }
        },
        new()
        {
            Id = "2",
            Username = "Username2"
        },
        new()
        {
            Id = "3",
            Username = "Username3"
        }
    };

    private readonly UserState _userState;

    public UserHandler(UserState userState)
    {
        _userState = userState;
    }

    public async Task<UserDto> GetUser(string id)
    {
        try
        {
            var found = _dummyUsers.FirstOrDefault(u => u.Id == id);
            if (found == null) throw new UserDoesNotExistException();

            return await Task.FromResult(found);
        }
        catch (KeyNotFoundException)
        {
            throw new UserDoesNotExistException();
        }
    }

    public async Task<UserDto> AddUser(UserDto toAdd)
    {
        if (toAdd == null) throw new NullReferenceException();

        _dummyUsers.Add(toAdd);
        return await Task.FromResult(toAdd);
    }

    public async Task<UserDto?> PatchUserAsync(UserDto userStateUser)
    {
        var index = _dummyUsers.IndexOf(userStateUser);
        _dummyUsers[index] = userStateUser;
        return await Task.FromResult(_dummyUsers[index]);
    }

    public async Task FollowUser(CachedUserDto userToFollow)
    {
        var existingUser = _dummyUsers.FirstOrDefault(u => u.Id == _userState.User?.Id);
        existingUser?.Following?.Add(userToFollow);
        _userState.User = existingUser;
        await Task.CompletedTask;
    }

    public async Task UnfollowUser(CachedUserDto userToFollow)
    {
        var existingUser = _dummyUsers.FirstOrDefault(u => u.Id == _userState.User?.Id);
        existingUser?.Following?.Remove(userToFollow);
        _userState.User = existingUser;
        await Task.CompletedTask;
    }
}