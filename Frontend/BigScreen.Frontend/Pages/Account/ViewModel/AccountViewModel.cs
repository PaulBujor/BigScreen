using BigScreen.Core.Models.BigScreen;
using BigScreen.Frontend.Client.Handlers.Interfaces;
using BigScreen.Frontend.Client.Security;

namespace BigScreen.Frontend.Pages.Account.ViewModel;

public class AccountViewModel : IAccountViewModel
{
    private readonly IUserHandler _userHandler;
    private readonly UserState _userState;
    private bool _isFollowing;

    public AccountViewModel(IUserHandler userHandler, UserState userState)
    {
        _userHandler = userHandler;
        _userState = userState;
        _userState.OnUserStateChange += FollowStateHasChanged;
    }

    public Action? OnFollowStateChange { get; set; }
    public Action? OnUserStateChange { get; set; }

    public UserDto? User { get; private set; }

    public async Task InitializeAsync(string userId)
    {
        if (userId == _userState.User?.Id)
        {
            User = _userState.User;
            _userState.OnUserStateChange += UserStateHasChanged;
            return;
        }

        _userState.OnUserStateChange -= UserStateHasChanged;


        if (User == null || (User != null && User.Id != userId)) User = await _userHandler.GetUser(userId);

        FollowStateHasChanged();
    }

    public bool IsFollowing()
    {
        return _isFollowing;
    }

    public async Task FollowUser()
    {
        if (User == null) return;

        await _userHandler.FollowUser(User.GetCachedVersion());
    }

    public async Task UnfollowUser()
    {
        if (User == null) return;

        await _userHandler.UnfollowUser(User.GetCachedVersion());
    }

    private void FollowStateHasChanged()
    {
        UpdateFollowState();
        OnFollowStateChange?.Invoke();
    }

    private void UserStateHasChanged()
    {
        if (User?.Id == _userState.User?.Id)
        {
            User = _userState.User;
            OnUserStateChange?.Invoke();
        }
    }

    private void UpdateFollowState()
    {
        _isFollowing = _userState.User?.Following?.FirstOrDefault(u => u.Id == User?.Id) != null;
    }
}