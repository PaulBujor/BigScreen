using BigScreen.Core.Models.BigScreen;

namespace BigScreen.Frontend.Components.SelectTopList.ViewModel;

public interface ISelectTopListViewModel
{
    Action? OnUserStateHasChanged { get; set; }
    IEnumerable<CachedTopListDto> GetTopLists();
    Task AddToTopListAsync(string topListId, CachedMovieDto movieDto);
}