using BigScreen.Core.Models.TMDb;
using BigScreen.Frontend.Core.Enums;

namespace BigScreen.Frontend.Components.SearchResult.ViewModel;

public interface ISearchResultViewModel
{
    SearchResultDto Result { get; set; }
    SearchFilter FilterContext { get; set; }
    string GetResultHref();
    string GetTypeHref();
    string GetTypeDisplay();
}