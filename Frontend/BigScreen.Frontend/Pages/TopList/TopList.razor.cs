using BigScreen.Core.Models.BigScreen;
using BigScreen.Frontend.Pages.TopList.ViewModel;
using Microsoft.AspNetCore.Components;

namespace BigScreen.Frontend.Pages.TopList;

public partial class TopList : ComponentBase
{
    private TopListDto? _topList;

    [Parameter]
    public string Id { get; set; } = null!;

    [Inject]
    private ITopListViewModel ViewModel { get; set; } = null!;

    [Inject]
    private NavigationManager NavigationManager { get; set; } = null!;

    protected override async Task OnInitializedAsync()
    {
        try
        {
            await ViewModel.InitializeAsync(Id);
        }
        catch (InvalidOperationException)
        {
            NavigationManager.NavigateTo("/topListNotFound");
        }

        _topList = ViewModel.GetTopList();
    }

    private string GetPathToOwner() => $"account/{_topList?.Owner?.Id}";

    private async Task RemoveMedia(string mediaId)
    {
        _topList = await ViewModel.RemoveMediaAsync(mediaId);
        StateHasChanged();
    }
}