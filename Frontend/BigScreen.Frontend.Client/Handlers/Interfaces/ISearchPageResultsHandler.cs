using BigScreen.Core.Models.TMDb;
using BigScreen.Frontend.Core.Enums;

namespace BigScreen.Frontend.Client.Handlers.Interfaces;

public interface ISearchPageResultsHandler
{
    Task<SearchPageResultsDto?> GetSearchPageResults(SearchFilter type, string query, int page);
}