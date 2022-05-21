using BigScreen.SDK.WebAPI.Core;

namespace BigScreen.SDK.WebAPI.Abstractions;

public interface IDataAccess<TDto> where TDto : BaseDto
{
    Task<TDto> GetAsync(string id, string partitionKey);
    Task<TDto> CreateAsync(TDto dto);
    Task<TDto> UpdateAsync(TDto dto);
    Task DeleteByIdAsync(string id, string partitionKey);
    Task DeleteAsync(TDto dto);
    Task<List<TDto>> GetAllAsync();
    Task<List<TDto>> GetAllAsync(string partitionKey);
}