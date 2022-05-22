using AutoMapper;
using BigScreen.SDK.DataAccess.Abstractions;
using BigScreen.SDK.DataAccess.Core;
using BigScreen.SDK.DataAccess.Extensions;
using BigScreen.SDK.WebAPI.Abstractions;
using BigScreen.SDK.WebAPI.Core;

namespace BigScreen.SDK.WebAPI;

public class DataAccess<TDto, TDbEntry> : IDataAccess<TDto> where TDto : BaseDto where TDbEntry : BaseDbEntry
{
    private readonly IDbSet<TDbEntry> _dbSet;
    private readonly IMapper _mapper;

    public DataAccess(IMapper mapper, IDbSet<TDbEntry> dbSet)
    {
        _mapper = mapper;
        _dbSet = dbSet;
    }

    public async Task<List<TDto>> GetAsync()
    {
        var resultEntry = _dbSet.ToList();
        var resultDto = _mapper.Map<List<TDbEntry>, List<TDto>>(resultEntry);
        return await Task.FromResult(resultDto);
    }

    public async Task<TDto> GetAsync(string key)
    {
        var resultEntry = _dbSet.FirstOrDefault(entry => entry.Id == key);
        var resultDto = _mapper.Map<TDbEntry, TDto>(resultEntry!);
        return await Task.FromResult(resultDto);
    }

    public async Task<TDto> CreateAsync(TDto dto)
    {
        var entry = _mapper.Map<TDto, TDbEntry>(dto);
        var result = await _dbSet.CreateAsync(entry);
        return _mapper.Map<TDbEntry, TDto>(result);
    }

    public async Task<TDto> UpdateAsync(TDto dto)
    {
        var entry = _mapper.Map<TDto, TDbEntry>(dto);
        var result = await _dbSet.UpdateAsync(entry);
        return _mapper.Map<TDbEntry, TDto>(result);
    }

    public Task DeleteAsync(string key)
    {
        var dto = _dbSet.FirstOrDefault(entry => entry.Id == key);
        return _dbSet.DeleteByIdAsync(dto!.Id!, dto.GetPartitionKeyValue());
    }
}