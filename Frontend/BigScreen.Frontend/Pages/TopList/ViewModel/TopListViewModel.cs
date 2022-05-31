using BigScreen.Core.Models.BigScreen;
using BigScreen.Frontend.Client.Handlers.Interfaces;
using BigScreen.Frontend.Components.ConfirmDelete;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace BigScreen.Frontend.Pages.TopList.ViewModel;

public class TopListViewModel : ITopListViewModel
{
    private readonly IDialogService _dialogService;
    private readonly ITopListHandler _handler;

    private readonly NavigationManager _navigationManager;

    private TopListDto? _topList;

    public TopListViewModel(ITopListHandler handler, NavigationManager navigationManager, IDialogService dialogService)
    {
        _handler = handler;
        _navigationManager = navigationManager;
        _dialogService = dialogService;
    }

    public async Task InitializeAsync(string toplistId)
    {
        if (_topList == null || _topList?.Id != toplistId)
        {
            _topList = await _handler.GetTopListAsync(toplistId) ?? throw new InvalidOperationException();
        }
    }

    public TopListDto GetTopList() => _topList!;

    public async Task<TopListDto> RemoveMediaAsync(string id)
    {
        _topList = await _handler.RemoveMediaFromTopListAsync(_topList!.Id!, id);
        return _topList;
    }

    public async Task DeleteTopList()
    {
        var parameters = new DialogParameters();
        parameters.Add("Title", _topList?.Title);
        parameters.Add("Id", _topList?.Id);
        var dialog = _dialogService.Show<ConfirmDelete>(_topList?.Title, parameters);
        var result = await dialog.Result;
        if ((string?)result.Data == _topList?.Id)
        {
            await _handler.DeleteTopListAsync(_topList?.Id!);
            _navigationManager.NavigateTo($"account/{_topList?.Owner?.Id}");
        }
    }
}