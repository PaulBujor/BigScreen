using BigScreen.Core.Models.BigScreen;
using BigScreen.Frontend.Client.Handlers.Interfaces;
using BigScreen.Frontend.Client.Security;
using BigScreen.Frontend.Core.Exceptions;

namespace BigScreen.Frontend.Components.SelectTopList.ViewModel;

public class SelectTopListViewModel : ISelectTopListViewModel
{
    private readonly ITopListHandler _handler;
    private readonly UserState _userState;

    public SelectTopListViewModel(UserState userState, ITopListHandler handler)
    {
        _userState = userState;
        _handler = handler;
        _userState.OnUserStateChange += OnUserStateChange;
    }

    public Action? OnUserStateHasChanged { get; set; }

    public IEnumerable<CachedTopListDto> GetTopLists()
    {
        return _userState.User?.SavedTopLists ?? throw new UserDoesNotExistException();
    }

    public async Task AddToTopListAsync(string topListId, CachedMovieDto movieDto)
    {
        await _handler.AddMovieToTopListAsync(topListId, movieDto);
    }

    private void OnUserStateChange()
    {
        OnUserStateHasChanged?.Invoke();
    }
}