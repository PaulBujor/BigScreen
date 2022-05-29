using BigScreen.Core.Models.BigScreen;
using Newtonsoft.Json;

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
        Console.WriteLine($"User state changed {_user?.Id} {DateTime.Now}\n{JsonConvert.SerializeObject(_user)}");
        OnUserStateChange?.Invoke();
    }
}