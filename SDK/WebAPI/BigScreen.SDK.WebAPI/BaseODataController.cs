using BigScreen.SDK.WebAPI.Abstractions;
using BigScreen.SDK.WebAPI.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Formatter;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.Azure.Cosmos;

namespace BigScreen.SDK.WebAPI;

public abstract class BaseODataController<TDto> : ODataController where TDto : BaseDto
{
    private readonly IDataAccess<TDto> _dataAccess;

    protected BaseODataController(IDataAccess<TDto> dataAccess)
    {
        _dataAccess = dataAccess;
    }

    [EnableQuery]
    public virtual async Task<IActionResult> GetAsync()
    {
        try
        {
            return Ok(await _dataAccess.GetAsync());
        }
        catch (CosmosException e)
        {
            return StatusCode((int) e.StatusCode);
        }
    }

    [EnableQuery]
    public virtual async Task<IActionResult> GetAsync([FromODataUri] string key)
    {
        try
        {
            return Ok(await _dataAccess.GetAsync(key));
        }
        catch (CosmosException e)
        {
            return StatusCode((int) e.StatusCode);
        }
    }

    public virtual async Task<IActionResult> PostAsync([FromBody] TDto dto)
    {
        try
        {
            return Ok(await _dataAccess.CreateAsync(dto));
        }
        catch (CosmosException e)
        {
            return StatusCode((int) e.StatusCode);
        }
    }

    public virtual async Task<IActionResult> PatchAsync([FromBody] TDto dto)
    {
        try
        {
            return Ok(await _dataAccess.UpdateAsync(dto));
        }
        catch (CosmosException e)
        {
            return StatusCode((int) e.StatusCode);
        }
        catch (InvalidOperationException e)
        {
            return BadRequest(e.Message);
        }
    }

    public virtual async Task<IActionResult> DeleteAsync([FromODataUri] string key)
    {
        try
        {
            await _dataAccess.DeleteAsync(key);
            return NoContent();
        }
        catch (CosmosException e)
        {
            return StatusCode((int) e.StatusCode);
        }
    }
}