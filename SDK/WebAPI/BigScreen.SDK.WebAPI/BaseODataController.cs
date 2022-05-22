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

    [HttpGet]
    [EnableQuery]
    public virtual async Task<IActionResult> GetAsync([FromODataUri] string id,
        [FromODataUri] string partitionKey)
    {
        try
        {
            return Ok(await _dataAccess.GetAsync(id, partitionKey));
        }
        catch (CosmosException e)
        {
            return StatusCode((int) e.StatusCode);
        }
    }

    [HttpGet]
    [EnableQuery]
    public virtual async Task<IActionResult> GetAsync()
    {
        try
        {
            return Ok(await _dataAccess.GetAllAsync());
        }
        catch (CosmosException e)
        {
            return StatusCode((int) e.StatusCode);
        }
    }

    [HttpGet]
    [EnableQuery]
    public virtual async Task<IActionResult> GetAsync([FromODataUri] string partitionKey)
    {
        try
        {
            return Ok(await _dataAccess.GetAllAsync(partitionKey));
        }
        catch (CosmosException e)
        {
            return StatusCode((int) e.StatusCode);
        }
    }

    [HttpPost]
    public virtual async Task<IActionResult> Post([FromBody] TDto dto)
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

    [HttpPatch]
    public virtual async Task<IActionResult> UpdateAsync([FromBody] TDto dto)
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

    [HttpDelete]
    public virtual async Task<IActionResult> DeleteAsync([FromODataUri] string id,
        [FromODataUri] string partitionKey)
    {
        try
        {
            await _dataAccess.DeleteByIdAsync(id, partitionKey);
            return NoContent();
        }
        catch (CosmosException e)
        {
            return StatusCode((int) e.StatusCode);
        }
    }

    [HttpDelete]
    public virtual async Task<IActionResult> DeleteAsync([FromBody] TDto dto)
    {
        try
        {
            await _dataAccess.DeleteAsync(dto);
            return NoContent();
        }
        catch (CosmosException e)
        {
            return StatusCode((int) e.StatusCode);
        }
    }
}