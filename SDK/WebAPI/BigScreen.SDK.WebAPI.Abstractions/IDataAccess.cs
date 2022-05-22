using BigScreen.SDK.WebAPI.Core;

namespace BigScreen.SDK.WebAPI.Abstractions;

public interface IDataAccess<TDto> where TDto : BaseDto
{
    Task<List<TDto>> GetAsync();
    Task<TDto> GetAsync(string key);
    Task<TDto> CreateAsync(TDto dto);
    Task<TDto> UpdateAsync(TDto dto);
    Task DeleteAsync(string key);
}