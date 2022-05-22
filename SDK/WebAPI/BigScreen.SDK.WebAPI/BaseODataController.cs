using System.Web.Http;
using BigScreen.SDK.WebAPI.Abstractions;
using BigScreen.SDK.WebAPI.Core;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Cosmos;

namespace BigScreen.SDK.WebAPI;

[ApiController]
public abstract class BaseODataController<TDto> : ODataController where TDto : BaseDto
{
    private readonly IDataAccess<TDto> _dataAccess;

    protected BaseODataController(IDataAccess<TDto> dataAccess)
    {
        _dataAccess = dataAccess;
    }


    [Microsoft.AspNetCore.Mvc.HttpPost]
    public virtual async Task<IHttpActionResult> Post([Microsoft.AspNetCore.Mvc.FromBody] TDto dto)
    {
        try
        {
            return Ok(await _dataAccess.CreateAsync(dto));
        }
        catch (CosmosException e)
        {
            return StatusCode(e.StatusCode);
        }
    }

    [Microsoft.AspNetCore.Mvc.HttpGet]
    [EnableQuery]
    public virtual async Task<IHttpActionResult> GetAsync([FromODataUri] string id,
        [FromODataUri] string partitionKey)
    {
        try
        {
            return Ok(await _dataAccess.GetAsync(id, partitionKey));
        }
        catch (CosmosException e)
        {
            return StatusCode(e.StatusCode);
        }
    }

    [Microsoft.AspNetCore.Mvc.HttpGet]
    [EnableQuery]
    public virtual async Task<IHttpActionResult> GetAllAsync()
    {
        try
        {
            return Ok(await _dataAccess.GetAllAsync());
        }
        catch (CosmosException e)
        {
            return StatusCode(e.StatusCode);
        }
    }

    [Microsoft.AspNetCore.Mvc.HttpGet]
    [EnableQuery]
    public virtual async Task<IHttpActionResult> GetAllAsync([FromODataUri] string partitionKey)
    {
        try
        {
            return Ok(await _dataAccess.GetAllAsync(partitionKey));
        }
        catch (CosmosException e)
        {
            return StatusCode(e.StatusCode);
        }
    }

    [Microsoft.AspNetCore.Mvc.HttpPatch]
    public virtual async Task<IHttpActionResult> UpdateAsync([Microsoft.AspNetCore.Mvc.FromBody] TDto dto)
    {
        try
        {
            return Ok(await _dataAccess.UpdateAsync(dto));
        }
        catch (CosmosException e)
        {
            return StatusCode(e.StatusCode);
        }
        catch (InvalidOperationException e)
        {
            return InternalServerError(e);
        }
    }

    [Microsoft.AspNetCore.Mvc.HttpDelete]
    public virtual async Task<IHttpActionResult> DeleteAsync([FromODataUri] string id,
        [FromODataUri] string partitionKey)
    {
        try
        {
            await _dataAccess.DeleteByIdAsync(id, partitionKey);
            return Ok(204);
        }
        catch (CosmosException e)
        {
            return StatusCode(e.StatusCode);
        }
    }

    [Microsoft.AspNetCore.Mvc.HttpDelete]
    public virtual async Task<IHttpActionResult> DeleteAsync([Microsoft.AspNetCore.Mvc.FromBody] TDto dto)
    {
        try
        {
            await _dataAccess.DeleteAsync(dto);
            return Ok(204);
        }
        catch (CosmosException e)
        {
            return StatusCode(e.StatusCode);
        }
    }
}