using BigScreen.Frontend.Core;
using BigScreen.Frontend.Core.Attributes;
using BigScreen.SDK.Client.Abstractions;
using BigScreen.SDK.Utilities;
using Microsoft.AspNetCore.WebUtilities;
using Newtonsoft.Json;

namespace BigScreen.Frontend.Client;

public class TmdbClient<TDto> : IClient<TDto> where TDto : TmdbDto
{
    //todo move to KeyVault
    private const string ApiKey = "460ff555602c9fc58a41487667e40b74";

    private readonly HttpClient _httpClient;

    public TmdbClient(IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient(TmdbClientConstants.ClientName);
    }

    public async Task<TDto?> GetAsync(string? id, string? additionalUri = null,
        Dictionary<string, string>? query = null)
    {
        var responseMessage = await _httpClient.GetAsync(CreateUri(id, additionalUri, query));
        responseMessage.EnsureSuccessStatusCode();
        var result = await responseMessage.Content.ReadAsStringAsync();
        var obj = JsonConvert.DeserializeObject<TDto>(result);
        return obj;
    }

    private string CreateUri(string? id, string? additionalUri, Dictionary<string, string>? query)
    {
        var uri = $"{typeof(TDto).GetAttribute<TmdbDtoAttribute>().RequestUri}";
        if (!string.IsNullOrEmpty(id))
        {
            uri += string.IsNullOrEmpty(uri) ? id : $"/{id}";
        }

        if (!string.IsNullOrEmpty(additionalUri))
        {
            uri += string.IsNullOrEmpty(uri) ? additionalUri : $"/{additionalUri}";
        }

        if (query != null && query.Any())
        {
            uri = QueryHelpers.AddQueryString(uri, query);
        }

        uri = QueryHelpers.AddQueryString(uri, "api_key", ApiKey);

        return uri;
    }
}