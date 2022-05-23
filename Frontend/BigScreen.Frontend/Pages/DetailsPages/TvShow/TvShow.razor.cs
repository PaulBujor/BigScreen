using Microsoft.AspNetCore.Components;

namespace BigScreen.Frontend.Pages.DetailsPages.TvShow;

public partial class TvShow : ComponentBase
{
    [Parameter]
    public int Id { get; set; }
}