using Microsoft.AspNetCore.Components;

namespace BigScreen.Frontend.Components.Card;

public partial class Card : ComponentBase
{
    [Parameter]
    public int? Id { get; set; }
    
    [Parameter]
    public string? Image { get; set; }
    
    [Parameter]
    public string? Header { get; set; }
    
    [Parameter]
    public string? Caption { get; set; }
    
    [Parameter]
    public string? Url { get; set; }
}