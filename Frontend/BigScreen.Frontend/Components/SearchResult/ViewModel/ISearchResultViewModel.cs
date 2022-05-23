namespace BigScreen.Frontend.Components.SearchResult.ViewModel;

using BigScreen.Core.Models.TMDb;
using Core.Enums;

public interface ISearchResultViewModel
{
    SearchResultDto Result { get; set; }
    SearchFilter FilterContext { get; set; }
    string GetResultHref();
    string GetTypeHref();
    string GetTypeDisplay();
}