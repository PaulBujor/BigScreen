using BigScreen.Core.Models.BigScreen;
using BigScreen.SDK.WebAPI;
using BigScreen.SDK.WebAPI.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web.Resource;

namespace BigScreen.Backend.Controllers;

public class UsersController : BaseODataController<UserDto>
{
    public UsersController(IDataAccess<UserDto> dataAccess) : base(dataAccess)
    {
    }

    [Authorize]
    [RequiredScope(RequiredScopesConfigurationKey = "AzureAdB2C:Scopes")]
    public override Task<IActionResult> PostAsync(UserDto dto)
    {
        return base.PostAsync(dto);
    }

    [Authorize]
    [RequiredScope(RequiredScopesConfigurationKey = "AzureAdB2C:Scopes")]
    public override Task<IActionResult> PatchAsync(UserDto dto)
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