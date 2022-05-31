using BigScreen.Core.Models.BigScreen;
using BigScreen.SDK.WebAPI;
using BigScreen.SDK.WebAPI.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web.Resource;

namespace BigScreen.Backend.Controllers;

public class CommentsController : BaseODataController<CommentDto>
{
    public CommentsController(IDataAccess<CommentDto> dataAccess) : base(dataAccess)
    {
    }

    [Authorize]
    [RequiredScope(RequiredScopesConfigurationKey = "AzureAdB2C:Scopes")]
    public override Task<IActionResult> PostAsync(CommentDto dto)
    {
        return base.PostAsync(dto);
    }

    [Authorize]
    [RequiredScope(RequiredScopesConfigurationKey = "AzureAdB2C:Scopes")]
    public override Task<IActionResult> PatchAsync(CommentDto dto)
    {
        return base.PatchAsync(dto);
    }

    [Authorize]
    [RequiredScope(RequiredScopesConfigurationKey = "AzureAdB2C:Scopes")]
    public override Task<IActionResult> DeleteAsync(string key)
    {
        return base.DeleteAsync(key);
    }
}