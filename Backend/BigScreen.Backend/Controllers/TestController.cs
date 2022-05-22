using BigScreen.Backend.Core.Models;
using BigScreen.SDK.WebAPI;
using BigScreen.SDK.WebAPI.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Formatter;

namespace BigScreen.Backend.Controllers;

public class TestController : BaseODataController<TestDto>
{
    public TestController(IDataAccess<TestDto> dataAccess) : base(dataAccess)
    {
    }

    public override async Task<IActionResult> Post([FromBody] TestDto dto)
    {
        return await base.Post(dto);
    }

    [Route("{id}/{partitionKey}")]
    public override async Task<IActionResult> GetAsync([FromODataUri] string id,
        [FromODataUri] string partitionKey)
    {
        return await base.GetAsync(id, partitionKey);
    }

    [Route("")]
    public override async Task<IActionResult> GetAsync()
    {
        return await base.GetAsync();
    }

    [Route("{partitionKey}")]
    public override async Task<IActionResult> GetAsync([FromODataUri] string partitionKey)
    {
        return await base.GetAsync(partitionKey);
    }

    [Route("")]
    public override async Task<IActionResult> UpdateAsync([FromBody] TestDto dto)
    {
        return await base.UpdateAsync(dto);
    }

    [Route("")]
    public override async Task<IActionResult> DeleteAsync([FromODataUri] string id,
        [FromODataUri] string partitionKey)
    {
        return await base.DeleteAsync(id, partitionKey);
    }

    [Route("")]
    public override async Task<IActionResult> DeleteAsync([FromBody] TestDto dto)
    {
        return await base.DeleteAsync(dto);
    }
}