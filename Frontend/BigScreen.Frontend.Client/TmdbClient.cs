using System.Net.Http.Json;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;
using BigScreen.Frontend.Core;
using BigScreen.Frontend.Core.Attributes;
using BigScreen.SDK.Client.Abstractions;
using BigScreen.SDK.Utilities;
using Microsoft.AspNetCore.WebUtilities;
using Newtonsoft.Json;

namespace BigScreen.Frontend.Client;

public class TmdbClient<TDto> : IClient<TDto> where TDto : TmdbDto
{

    private HttpClient _httpClient;
    //todo move to KeyVault
    private const string ApiKey = "460ff555602c9fc58a41487667e40b74";

    public TmdbClient(IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient(TmdbClientConstants.ClientName);
    }

    public async Task<TDto>? GetAsync(string? id, string? additionalUri = null, Dictionary<string, string>? query = null)
    {
        var requestUri = typeof(TDto).GetAttribute<TmdbDtoAttribute>().RequestUri;
        var responseMessage = await _httpClient.GetAsync(requestUri + CreateUri(id,additionalUri,query));
        responseMessage.EnsureSuccessStatusCode();
        var result = await responseMessage.Content.ReadAsStringAsync();
        var obj = JsonConvert.DeserializeObject<TDto>(result);
        return obj!;
    }

    private string CreateUri(string? id, string? additionalUri, Dictionary<string, string>? query)
    {
        var uri = string.Empty;
        if (!string.IsNullOrEmpty(id))
        {
            uri += id;
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

        return $"/{uri}";
    }

}