using BigScreen.Core.Models.TMDb;
using BigScreen.Frontend.Client.Handlers.Interfaces;
using BigScreen.Frontend.Core.Enums;

namespace BigScreen.Frontend.Client.Handlers;

public class SearchPageResultsHandler : ISearchPageResultsHandler
{
    private readonly TmdbClient<SearchPageResultsDto> _client;

    public SearchPageResultsHandler(TmdbClient<SearchPageResultsDto> client)
    {
        _client = client;
    }

    public async Task<SearchPageResultsDto?> GetSearchPageResultsAsync(SearchFilter type, string query, int page)
    {
        var queries = new Dictionary<string, string>();
        queries.Add("query", query);
        queries.Add("page", page.ToString());
        var results = await _client.GetAsync(additionalUri: GetSearchFilterQuery(type), query: queries);
        return results;
    }

    private string GetSearchFilterQuery(SearchFilter type) => type switch
    {
        SearchFilter.All => "multi",
        SearchFilter.Movies => "movie",
        SearchFilter.People => "person",
        SearchFilter.TvShows => "tv",
        _ => throw new ArgumentOutOfRangeException(nameof(type), $"Not expected search filter value: {type}")
    };
}