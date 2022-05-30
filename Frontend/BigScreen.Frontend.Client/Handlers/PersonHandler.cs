using BigScreen.Core.Models.TMDb;
using BigScreen.Frontend.Client.Handlers.Interfaces;

namespace BigScreen.Frontend.Client.Handlers;

public class PersonHandler : IPersonHandler
{
    private readonly TmdbClient<PersonDto> _client;

    public PersonHandler(TmdbClient<PersonDto> client)
    {
        _client = client;
    }

    public async Task<PersonDto?> GetPerson(int id)
    {
        var queries = new Dictionary<string, string>();
        queries.Add("append_to_response", "combined_credits");
        return await _client.GetAsync(id: id.ToString(), query: queries);
    }
}