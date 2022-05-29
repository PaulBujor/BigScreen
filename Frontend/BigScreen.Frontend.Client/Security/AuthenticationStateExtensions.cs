using BigScreen.Core.Models.BigScreen;
using Microsoft.AspNetCore.Components.Authorization;

namespace BigScreen.Frontend.Client.Security;

public static class AuthenticationStateExtensions
{
    public static string GetUsername(this AuthenticationState state)
    {
        return state.User.Identity?.Name ?? string.Empty;
    }

    public static string GetUserId(this AuthenticationState state)
    {
        return state.User.Claims.FirstOrDefault(claim => claim.Type == "oid")?.Value ?? string.Empty;
    }

    public static CachedUserDto GetCachedUserData(this AuthenticationState state)
    {
        return new CachedUserDto
        {
            Username = state.GetUsername(),
            Id = state.GetUserId()
        };
    }
}