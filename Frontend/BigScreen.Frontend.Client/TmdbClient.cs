using System.Net.Http.Json;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;
using BigScreen.Frontend.Core;
using BigScreen.Frontend.Core.Attributes;
using BigScreen.SDK.Client.Abstractions;
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

    public async Task<TDto>? GetAsync(string? id, string? query)
    {
        var responseMessage = await _httpClient.GetAsync(typeof(TmdbDto).GetCustomAttribute<TmdbDtoAttribute>()?.RequestUri);
        responseMessage.EnsureSuccessStatusCode();
        var result = await responseMessage.Content.ReadAsStringAsync();
        var obj = JsonConvert.DeserializeObject<TDto>(result);
        return obj!;
        
        // to be used
        // QueryHelpers.AddQueryString()

    }

}