using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;

namespace BigScreen.Frontend.Client.Security;

public class BigScreenMessageHandler : AuthorizationMessageHandler
{
    public BigScreenMessageHandler(IAccessTokenProvider provider, NavigationManager navigation) : base(provider,
        navigation)
    {
        ConfigureHandler(new[] {"https://localhost:7171/", "https://bigscreen-api.azurewebsites.net/"},
            new[] {"https://bigscreenapp.onmicrosoft.com/api/Write"});
    }
}