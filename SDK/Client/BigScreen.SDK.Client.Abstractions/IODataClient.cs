using BigScreen.SDK.WebAPI.Core;

namespace BigScreen.SDK.Client.Abstractions;

public interface IODataClient<TDto> where TDto : BaseDto
{
    Task<List<TDto>?> GetAllAsync(string? query = null);
    Task<TDto?> GetByIdAsync(string id);
    Task<TDto?> PostAsync(TDto dto);
    Task<TDto?> PatchAsync(TDto dto);
    Task<HttpResponseMessage> DeleteAsync(string id);
}