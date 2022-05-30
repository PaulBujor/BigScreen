using BigScreen.Frontend.Client.Handlers.Interfaces;
using BigScreen.Frontend.Core;

namespace BigScreen.Frontend.Client.Handlers;

public class DetailsPageHandler<TDetailsDto> : IDetailsPageHandler<TDetailsDto> where TDetailsDto : TmdbDto
{
    private readonly TmdbClient<TDetailsDto> _tmdbClient;

    public DetailsPageHandler(TmdbClient<TDetailsDto> tmdbClient)
    {
        _tmdbClient = tmdbClient;
    }

    public async Task<TDetailsDto?> GetMediaDetailsAsync(int id)
    {
        var queries = new Dictionary<string, string>();
        queries.Add("append_to_response", "credits,similar,recommendations");
        return await _tmdbClient.GetAsync(id: id.ToString(), query: queries);
    }
}