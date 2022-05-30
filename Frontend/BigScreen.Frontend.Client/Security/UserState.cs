using BigScreen.Core.Models.BigScreen;

namespace BigScreen.Frontend.Client.Security;

public class UserState
{
    private UserDto? _user;

    public UserDto? User
    {
        get => _user;
        set
        {
            _user = value;
            UserStateHasChanged();
        }
    }

    public Action? OnUserStateChange { get; set; }

    private void UserStateHasChanged()
    {
        OnUserStateChange?.Invoke();
    }
}