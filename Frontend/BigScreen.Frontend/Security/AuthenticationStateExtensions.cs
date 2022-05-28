using BigScreen.Core.Models.BigScreen;
using Microsoft.AspNetCore.Components.Authorization;

namespace BigScreen.Frontend.Security;

public static class AuthenticationStateExtensions
{
    private static string GetUsername(this AuthenticationState state)
    {
        return state.User.Identity?.Name ?? string.Empty;
    }

    private static string GetUserId(this AuthenticationState state)
    {
        return state.User.Claims.FirstOrDefault(claim => claim.Type == "oid")?.Value ?? string.Empty;
    }

    public static CachedUserDto GetUserData(this AuthenticationState state)
    {
        return new CachedUserDto
        {
            Username = state.GetUsername(),
            Id = state.GetUserId()
        };
    }
}