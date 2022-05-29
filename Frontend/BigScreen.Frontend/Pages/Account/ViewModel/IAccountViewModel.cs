using BigScreen.Core.Models.BigScreen;

namespace BigScreen.Frontend.Pages.Account.ViewModel;

public interface IAccountViewModel
{
    UserDto? User { get; }
    Action? OnFollowStateChange { get; set; }
    Task InitializeAsync(string userId);
    bool IsFollowing();
    Task FollowUser();
    Task UnfollowUser();
}