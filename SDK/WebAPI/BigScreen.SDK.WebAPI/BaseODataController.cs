using BigScreen.SDK.DataAccess.Exceptions;
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
        catch (ItemNotFoundException e)
        {
            return NotFound(e.Message);
        }
        catch (CosmosException e)
        {
            return StatusCode((int) e.StatusCode, e.Message);
        }
    }

    [EnableQuery]
    public virtual async Task<IActionResult> GetAsync([FromODataUri] string key)
    {
        try
        {
            return Ok(await _dataAccess.GetAsync(key));
        }
        catch (ItemNotFoundException e)
        {
            return NotFound(e.Message);
        }
        catch (CosmosException e)
        {
            return StatusCode((int) e.StatusCode, e.Message);
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
            return StatusCode((int) e.StatusCode, e.Message);
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
            return StatusCode((int) e.StatusCode, e.Message);
        }
        catch (ItemNotFoundException e)
        {
            return NotFound(e.Message);
        }
        catch (Exception e)
        {
            if (e.GetType() == typeof(ETagMismatchException) || e.GetType() == typeof(PartitionMismatchException))
                return BadRequest(e.Message);

            return StatusCode(500, e.Message);
        }
    }

    public virtual async Task<IActionResult> DeleteAsync([FromODataUri] string key)
    {
        try
        {
            await _dataAccess.DeleteAsync(key);
            return NoContent();
        }
        catch (ItemNotFoundException e)
        {
            return StatusCode(404, e.Message);
        }
        catch (CosmosException e)
        {
            return StatusCode((int) e.StatusCode, e.Message);
        }
    }
}