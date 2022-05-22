using BigScreen.Backend.Models;
using BigScreen.SDK.WebAPI;
using BigScreen.SDK.WebAPI.Abstractions;

namespace BigScreen.Backend.Controllers;

public class TestController : BaseODataController<TestDto>
{
    public TestController(IDataAccess<TestDto> dataAccess) : base(dataAccess)
    {
    }

    // public override async Task<IActionResult> Post([FromBody] TestDto dto)
    // {
    //     return await base.Post(dto);
    // }
    //
    // // [Route("{id}/{partitionKey}")]
    // public override async Task<IActionResult> GetAsync([FromODataUri] string id,
    //     [FromODataUri] string partitionKey)
    // {
    //     return await base.GetAsync(id, partitionKey);
    // }
    //
    // // [Route("{partitionKey}")]
    // public override async Task<IActionResult> GetAsync([FromODataUri] string partitionKey)
    // {
    //     return await base.GetAsync(partitionKey);
    // }
    //
    // public override async Task<IActionResult> UpdateAsync([FromBody] TestDto dto)
    // {
    //     return await base.UpdateAsync(dto);
    // }
    //
    // public override async Task<IActionResult> DeleteAsync([FromODataUri] string id,
    //     [FromODataUri] string partitionKey)
    // {
    //     return await base.DeleteAsync(id, partitionKey);
    // }
    //
    // public override async Task<IActionResult> DeleteAsync([FromBody] TestDto dto)
    // {
    //     return await base.DeleteAsync(dto);
    // }
}