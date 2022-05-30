using BigScreen.Core.Models.BigScreen;
using BigScreen.Frontend.Components.CreateTopList;
using BigScreen.Frontend.Core.Exceptions;
using BigScreen.Frontend.Pages.Account.ViewModel;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using MudBlazor;

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

    [Inject]
    private IDialogService DialogService { get; set; } = null!;

    [CascadingParameter]
    private Task<AuthenticationState> AuthenticationStateTask { get; set; } = null!;

    [Parameter]
    public string Id { get; set; } = null!;

    protected override async Task OnParametersSetAsync()
    {
        try
        {
            await InitializeAsync();
        }
        catch (UserDoesNotExistException)
        {
            NavigationManager.NavigateTo("/accountNotFound");
        }
    }

    protected override void OnInitialized()
    {
        ViewModel.OnFollowStateChange += FollowStateHasChanged;
        ViewModel.OnFollowStateChange += TopListStateHasChanged;
    }

    private async Task InitializeAsync()
    {
        await ViewModel.InitializeAsync(Id);
        if (ViewModel.User != null)
        {
            _username = ViewModel.User.Username;
            _following = ViewModel.User.Following ?? new List<CachedUserDto>();
            TopListStateHasChanged();
            FollowStateHasChanged();
        }
    }

    private void FollowStateHasChanged()
    {
        _isFollowing = ViewModel.IsFollowing();
        StateHasChanged();
    }

    private void TopListStateHasChanged()
    {
        _topLists = ViewModel.User?.SavedTopLists ?? new List<CachedTopListDto>();
        StateHasChanged();
    }

    private void CreateItem()
    {
        DialogService.Show<CreateTopList>("Create new Top List");
    }

    private string GetPathToAccount(string userId)
    {
        _tabIndex = 0;
        return $"/account/{userId}";
    }

    private string GetPathToTopList(string topListId) => $"/toplist/{topListId}";
}