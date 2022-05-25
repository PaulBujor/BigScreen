using BigScreen.Frontend.Client.Handlers.Interfaces;
using BigScreen.Frontend.Core;
using BigScreen.Frontend.Core.Enums;

namespace BigScreen.Frontend.Client.Handlers;

public class GeneralSearchPageResultsHandler<TGeneralSearchDto> : IGeneralSearchPageResultsHandler<TGeneralSearchDto> where TGeneralSearchDto : TmdbDto
{
    private readonly TmdbClient<TGeneralSearchDto> _client;

    public GeneralSearchPageResultsHandler(TmdbClient<TGeneralSearchDto> client)
    {
        _client = client;
    }

    public async Task<TGeneralSearchDto?> GetGeneralSearchBySortType(SortFilter filter, int page)
    {
        var queries = new Dictionary<string, string>();
        queries.Add("page", page.ToString());
        return await _client.GetAsync(additionalUri: GetSortFilterQuery(filter), query: queries);
    }

    private string GetSortFilterQuery(SortFilter type) => type switch
    {
        SortFilter.Popularity => "popular",
        SortFilter.Rating => "top_rated",
        _ => throw new ArgumentOutOfRangeException(nameof(type), $"Not expected sort filter value: {type}")
    };
}