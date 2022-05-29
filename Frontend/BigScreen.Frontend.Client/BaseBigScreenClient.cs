using System.Net.Http.Json;
using System.Reflection;
using System.Text;
using BigScreen.Frontend.Client.Constants;
using BigScreen.SDK.WebAPI.Core;
using BigScreen.SDK.WebAPI.Core.Attributes;
using Newtonsoft.Json;

namespace BigScreen.Frontend.Client;

public abstract class BaseBigScreenClient<TDto> where TDto : BaseDto
{
    private readonly HttpClient _httpClient;

    protected BaseBigScreenClient(IHttpClientFactory clientFactory)
    {
        _httpClient = clientFactory.CreateClient(BigScreenClientConstants.ClientName);
        _httpClient.BaseAddress =
            new Uri(
                $"{BigScreenClientConstants.GetBaseAddress()}/{typeof(TDto).GetCustomAttribute<EdmCollectionAttribute>()?.CollectionName}");
    }

    public async Task<List<TDto>?> GetAllAsync(string? querry = null)
    {
        var requestUri = _httpClient.BaseAddress!.ToString();
        if (!string.IsNullOrWhiteSpace(querry)) requestUri += querry;

        var responseMessage = await _httpClient.GetAsync(requestUri);
        responseMessage.EnsureSuccessStatusCode();
        var result = await responseMessage.Content.ReadAsStringAsync();

        var obj = JsonConvert.DeserializeObject<DtoResponseWrapper<TDto>>(result);
        var list = obj?.Values;

        return list;
    }


    public async Task<TDto?> GetByIdAsync(string id)
    {
        var responseMessage = await _httpClient.GetAsync(_httpClient.BaseAddress + id);
        var result = await responseMessage.Content.ReadAsStringAsync();

        var obj = JsonConvert.DeserializeObject<TDto>(result);

        return obj;
    }

    public async Task<TDto?> PostAsync(TDto dto)
    {
        var response = await _httpClient.PostAsJsonAsync("https://localhost:7171/api/Users/", dto);
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
        var responseMessage = await _httpClient.PatchAsync("https://localhost:7171/api/Users", requestContent);
        responseMessage.EnsureSuccessStatusCode();

        var result = await responseMessage.Content.ReadAsStringAsync();
        var obj = JsonConvert.DeserializeObject<TDto>(result);

        return obj;
    }

    public async Task<HttpResponseMessage> DeleteAsync(string id)
    {
        var response = await _httpClient.DeleteAsync("https://localhost:7171/api/Users/" + id);
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