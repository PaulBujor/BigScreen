namespace BigScreen.Frontend.Pages.DetailsPages.Movie;

using Microsoft.AspNetCore.Components;

public partial class Movie : ComponentBase
{
    [Parameter] public int Id { get; set; }
}