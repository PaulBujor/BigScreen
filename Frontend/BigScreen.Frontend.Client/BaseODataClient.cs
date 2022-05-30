using System.Net.Http.Json;
using System.Reflection;
using System.Text;
using BigScreen.Frontend.Client.Constants;
using BigScreen.SDK.WebAPI.Core;
using BigScreen.SDK.WebAPI.Core.Attributes;
using Newtonsoft.Json;

namespace BigScreen.Frontend.Client;

public abstract class BaseODataClient<TDto> where TDto : BaseDto
{
    private readonly HttpClient _httpClient;

    protected BaseODataClient(IHttpClientFactory clientFactory)
    {
        _httpClient = clientFactory.CreateClient(BigScreenClientConstants.ClientName);
        _httpClient.BaseAddress =
            new Uri(
                $"{BigScreenClientConstants.GetBaseAddress()}/{typeof(TDto).GetCustomAttribute<EdmCollectionAttribute>()?.CollectionName}");
    }

    public async Task<List<TDto>?> GetAllAsync(string? query = null)
    {
        /*var requestUri = "/";
        if (!string.IsNullOrWhiteSpace(query)) requestUri += query;*/

        var responseMessage = await _httpClient.GetAsync(query);
        responseMessage.EnsureSuccessStatusCode();
        var result = await responseMessage.Content.ReadAsStringAsync();

        var obj = JsonConvert.DeserializeObject<DtoResponseWrapper<TDto>>(result);
        var list = obj?.Values;

        return list;
    }


    public async Task<TDto?> GetByIdAsync(string id)
    {
        var responseMessage = await _httpClient.GetAsync("/" + id);
        var result = await responseMessage.Content.ReadAsStringAsync();

        var obj = JsonConvert.DeserializeObject<TDto>(result);

        return obj;
    }

    public async Task<TDto?> PostAsync(TDto dto)
    {
        var response = await _httpClient.PostAsJsonAsync("/", dto);
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
        var requestContent = new StringContent(serializedDto, Encoding.UTF8, "application/json");
        var responseMessage = await _httpClient.PatchAsync("/", requestContent);
        responseMessage.EnsureSuccessStatusCode();

        var result = await responseMessage.Content.ReadAsStringAsync();
        var obj = JsonConvert.DeserializeObject<TDto>(result);

        return obj;
    }

    public async Task<HttpResponseMessage> DeleteAsync(string id)
    {
        var response = await _httpClient.DeleteAsync("/" + id);
        response.EnsureSuccessStatusCode();
        return response;
    }
}

public class DtoResponseWrapper<TDto> where TDto : BaseDto
{
    [JsonIgnore]
    [JsonProperty("@odata.context")]
    public string? OdataContext { get; set; }

    [JsonProperty("value")] public List<TDto>? Values { get; set; }
}