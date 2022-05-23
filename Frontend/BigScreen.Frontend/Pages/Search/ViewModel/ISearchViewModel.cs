using BigScreen.Core.Models.TMDb;
using BigScreen.Frontend.Core.Enums;

namespace BigScreen.Frontend.Pages.Search.ViewModel;

public interface ISearchViewModel
{
    string SearchFilterText { get; }
    string SearchTextFieldText { get; }
    SearchFilter SearchFilter { get; set; }
    string SearchQuery { get; set; }
    SearchPageResultsDto? PageResults { get; }
    Action RefreshView { get; set; }
    int CurrentPage { get; set; }
    void DisposeViewModel();
}