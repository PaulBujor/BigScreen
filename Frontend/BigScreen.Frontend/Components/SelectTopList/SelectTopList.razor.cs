using BigScreen.Core.Models.BigScreen;
using BigScreen.Frontend.Components.SelectTopList.ViewModel;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace BigScreen.Frontend.Components.SelectTopList;

public partial class SelectTopList : ComponentBase
{
    private MudListItem _selectedItem;

    private object _selectedValue;

    private IList<CachedTopListDto> _topLists;
    [Inject] private ISelectTopListViewModel ViewModel { get; set; } = null!;

    [Inject] private IDialogService DialogService { get; set; } = null!;

    [CascadingParameter] private MudDialogInstance MudDialog { get; set; } = null!;

    [Parameter] public CachedMovieDto MovieDto { get; set; } = null!;

    protected override void OnInitialized()
    {
        UpdateTopLists();
        ViewModel.OnUserStateHasChanged += UpdateTopLists;
    }

    private void UpdateTopLists()
    {
        _topLists = (IList<CachedTopListDto>) ViewModel.GetTopLists();
        StateHasChanged();
    }

    private void CreateNewTopList()
    {
        DialogService.Show<CreateTopList.CreateTopList>("Create new Top List");
    }

    private async Task Save()
    {
        await ViewModel.AddToTopListAsync(_topLists[(int) _selectedValue].Id!, MovieDto);
        Close();
    }

    private void Close()
    {
        MudDialog.Close();
    }
}