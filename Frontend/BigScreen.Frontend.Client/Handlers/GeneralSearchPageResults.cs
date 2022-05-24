using BigScreen.Frontend.Client.Handlers.Interfaces;
using BigScreen.Frontend.Core;
using BigScreen.Frontend.Core.Enums;

namespace BigScreen.Frontend.Client.Handlers;

public class GeneralSearchPageResults<TGeneralSearchDto> : IGeneralSearchPageResults<TGeneralSearchDto> where TGeneralSearchDto : TmdbDto
{
    private readonly TmdbClient<TGeneralSearchDto> _client;

    public GeneralSearchPageResults(TmdbClient<TGeneralSearchDto> client)
    {
        _client = client;
    }

    public async Task<TGeneralSearchDto?> GetGeneralSearchBySortType(SortFilter filter) => await _client.GetAsync(additionalUri: GetSortFilterQuery(filter));

    private string GetSortFilterQuery(SortFilter type) => type switch
    {
        SortFilter.Latest => "latest",
        SortFilter.Popularity => "popular",
        SortFilter.Rating => "top_rated",
        _ => throw new ArgumentOutOfRangeException(nameof(type), $"Not expected sort filter value: {type}")
    };
}