using Microsoft.AspNetCore.Components;

namespace BigScreen.Frontend.Pages.Authentication;

public partial class Authentication : ComponentBase
{
    [Parameter]
    public string? Action { get; set; }
}