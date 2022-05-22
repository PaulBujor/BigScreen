using System.Web.Http;
using BigScreen.Backend.Core.Models;
using BigScreen.SDK.WebAPI;
using BigScreen.SDK.WebAPI.Abstractions;
using Microsoft.AspNet.OData;

namespace BigScreen.Backend.Controllers;

[Microsoft.AspNetCore.Mvc.Route("test")]
public class TestController : BaseODataController<TestDto>
{
    public TestController(IDataAccess<TestDto> dataAccess) : base(dataAccess)
    {
    }

    [Microsoft.AspNetCore.Mvc.Route("")]
    public override async Task<IHttpActionResult> Post([Microsoft.AspNetCore.Mvc.FromBody] TestDto dto)
    {
        return await base.Post(dto);
    }

    [Microsoft.AspNetCore.Mvc.Route("{id}/{partitionKey}")]
    public override async Task<IHttpActionResult> GetAsync([FromODataUri] string id,
        [FromODataUri] string partitionKey)
    {
        return await base.GetAsync(id, partitionKey);
    }

    [Microsoft.AspNetCore.Mvc.Route("")]
    public override async Task<IHttpActionResult> GetAllAsync()
    {
        return await base.GetAllAsync();
    }

    [Microsoft.AspNetCore.Mvc.Route("{partitionKey}")]
    public override async Task<IHttpActionResult> GetAllAsync([FromODataUri] string partitionKey)
    {
        return await base.GetAllAsync(partitionKey);
    }

    [Microsoft.AspNetCore.Mvc.Route("")]
    public override async Task<IHttpActionResult> UpdateAsync([Microsoft.AspNetCore.Mvc.FromBody] TestDto dto)
    {
        return await base.UpdateAsync(dto);
    }

    [Microsoft.AspNetCore.Mvc.Route("")]
    public override async Task<IHttpActionResult> DeleteAsync([FromODataUri] string id,
        [FromODataUri] string partitionKey)
    {
        return await base.DeleteAsync(id, partitionKey);
    }

    [Microsoft.AspNetCore.Mvc.Route("")]
    public override async Task<IHttpActionResult> DeleteAsync([FromBody] TestDto dto)
    {
        return await base.DeleteAsync(dto);
    }
}