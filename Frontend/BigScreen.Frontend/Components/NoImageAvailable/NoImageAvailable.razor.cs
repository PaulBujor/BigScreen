using Microsoft.AspNetCore.Components;

namespace BigScreen.Frontend.Components.NoImageAvailable;

public partial class NoImageAvailable : ComponentBase
{
    [Parameter]
    public string? Height { get; set; } = "138px";

    [Parameter]
    public string? Width { get; set; } = "92px";

    public string GetStyle() => $"width: {Width}; height: {Height};";
}