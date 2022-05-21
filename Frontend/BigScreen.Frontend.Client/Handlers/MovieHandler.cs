using BigScreen.Core.Models.TMDb;
using BigScreen.Frontend.Client.Handlers.Interfaces;

namespace BigScreen.Frontend.Client.Handlers;

public class MovieHandler : IMovieHandler
{
    private readonly TmdbClient<MovieDto> _client;

    public MovieHandler(TmdbClient<MovieDto> client)
    {
        _client = client;
    }

    public async Task<MovieDto?> GetMovieById(string id)
    {
        return await _client.GetAsync(id);
    }
}