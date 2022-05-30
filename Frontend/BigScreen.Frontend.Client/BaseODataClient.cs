using System.Net.Mime;
using System.Reflection;
using System.Text;
using BigScreen.Frontend.Client.Constants;
using BigScreen.SDK.Client.Abstractions;
using BigScreen.SDK.WebAPI.Core;
using BigScreen.SDK.WebAPI.Core.Attributes;
using Newtonsoft.Json;

namespace BigScreen.Frontend.Client;

public class BaseODataClient<TDto> : IODataClient<TDto> where TDto : BaseDto
{
    private readonly HttpClient _httpClient;
    private readonly string? _endpoint = typeof(TDto).GetCustomAttribute<EdmCollectionAttribute>()?.CollectionName;

    public BaseODataClient(IHttpClientFactory clientFactory)
    {
        _httpClient = clientFactory.CreateClient(BigScreenClientConstants.ClientName);
    }

    public async Task<List<TDto>?> GetAllAsync(string? query = null)
    {
        var responseMessage = await _httpClient.GetAsync($"{_endpoint}{query}");
        responseMessage.EnsureSuccessStatusCode();
        var result = await responseMessage.Content.ReadAsStringAsync();

        var obj = JsonConvert.DeserializeObject<DtoResponseWrapper<TDto>>(result);
        var list = obj?.Values;

        return list;
    }


    public async Task<TDto?> GetByIdAsync(string id)
    {
        var responseMessage = await _httpClient.GetAsync($"{_endpoint}/{id}");
        responseMessage.EnsureSuccessStatusCode();
        var result = await responseMessage.Content.ReadAsStringAsync();

        var obj = JsonConvert.DeserializeObject<TDto>(result);

        return obj;
    }

    public async Task<TDto?> PostAsync(TDto dto)
    {
        var serializedDto = JsonConvert.SerializeObject(dto, new JsonSerializerSettings
        {
            NullValueHandling = NullValueHandling.Ignore
        });
        var requestContent = new StringContent(serializedDto, Encoding.UTF8, MediaTypeNames.Application.Json);
        var response = await _httpClient.PostAsync(_endpoint, requestContent);
        response.EnsureSuccessStatusCode();

        var result = await response.Content.ReadAsStringAsync();
        var obj = JsonConvert.DeserializeObject<TDto>(result);

        return obj;
    }

    public async Task<TDto?> PatchAsync(TDto dto)
    {
        var serializedDto = JsonConvert.SerializeObject(dto, new JsonSerializerSettings
        {
            NullValueHandling = NullValueHandling.Ignore
        });
        var requestContent = new StringContent(serializedDto, Encoding.UTF8, MediaTypeNames.Application.Json);
        var responseMessage = await _httpClient.PatchAsync(_endpoint, requestContent);
        responseMessage.EnsureSuccessStatusCode();

        var result = await GetByIdAsync(dto.Id!);

        return result;
    }

    public async Task<HttpResponseMessage> DeleteAsync(string id)
    {
        var response = await _httpClient.DeleteAsync($"{_endpoint}/{id}");
        response.EnsureSuccessStatusCode();
        return response;
    }
}

internal class DtoResponseWrapper<TDto> where TDto : BaseDto
{
    [JsonIgnore]
    [JsonProperty("@odata.context")]
    public string? OdataContext { get; set; }

    [JsonProperty("value")] public List<TDto>? Values { get; set; }
}