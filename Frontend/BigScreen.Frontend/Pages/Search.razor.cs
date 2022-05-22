using Microsoft.AspNetCore.Components;

namespace BigScreen.Frontend.Pages;

public partial class Search : ComponentBase
{
    [Parameter] public string? Query { get; set; }

    protected override Task OnInitializedAsync()
    {
        // todo check for query and call api
        return base.OnInitializedAsync();
    }
}