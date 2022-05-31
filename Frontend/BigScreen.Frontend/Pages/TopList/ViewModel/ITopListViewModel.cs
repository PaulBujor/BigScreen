using BigScreen.Core.Models.BigScreen;

namespace BigScreen.Frontend.Pages.TopList.ViewModel;

public interface ITopListViewModel
{
    Task InitializeAsync(string toplistId);
    TopListDto GetTopList();

    Task<TopListDto> RemoveMediaAsync(string id);
    Task DeleteTopList();
}