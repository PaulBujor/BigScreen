using BigScreen.Core.Models.BigScreen;
using BigScreen.Frontend.Core.Exceptions;
using BigScreen.Frontend.Pages.Account.ViewModel;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;

namespace BigScreen.Frontend.Pages.Account;

public partial class Account : ComponentBase
{
    private ICollection<CachedUserDto> _following = new List<CachedUserDto>();

    private bool _isFollowing;
    private int _tabIndex;

    private ICollection<CachedTopListDto> _topLists = new List<CachedTopListDto>();

    private string? _username = "Account";

    [Inject]
    private IAccountViewModel ViewModel { get; set; } = null!;

    [Inject]
    private NavigationManager NavigationManager { get; set; } = null!;

    [CascadingParameter]
    private Task<AuthenticationState> AuthenticationStateTask { get; set; } = null!;

    [Parameter]
    public string Id { get; set; } = null!;

    protected override async Task OnParametersSetAsync()
    {
        try
        {
            await Initialize();
        }
        catch (UserDoesNotExistException)
        {
            NavigationManager.NavigateTo("/accountNotFound");
        }
    }

    protected override void OnInitialized()
    {
        ViewModel.OnFollowStateChange += FollowStateHasChanged;
    }

    private async Task Initialize()
    {
        await ViewModel.InitializeAsync(Id);
        if (ViewModel.User != null)
        {
            _username = ViewModel.User.Username;
            _topLists = ViewModel.User.SavedTopLists ?? new List<CachedTopListDto>();
            _following = ViewModel.User.Following ?? new List<CachedUserDto>();
            FollowStateHasChanged();
        }
    }

    private void FollowStateHasChanged()
    {
        _isFollowing = ViewModel.IsFollowing();
        StateHasChanged();
    }

    private void CreateItem()
    {
        Console.WriteLine("Create toplist!");
    }

    private string GetPathToAccount(string userId)
    {
        _tabIndex = 0;
        return $"/account/{userId}";
    }
}