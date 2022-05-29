using BigScreen.Core.Models.BigScreen;

namespace BigScreen.Frontend.Client.Handlers.Interfaces;

public interface IUserHandler
{
    Task<UserDto> GetUser(string id);
    Task<UserDto> AddUser(UserDto toAdd);
    Task<UserDto?> PatchUserAsync(UserDto userStateUser);
    Task FollowUser(CachedUserDto userToFollow);
    Task UnfollowUser(CachedUserDto userToFollow);
}