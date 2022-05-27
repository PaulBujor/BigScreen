using Microsoft.AspNetCore.Components;

namespace BigScreen.Frontend.Pages.DetailsPages.Movie;

public partial class Movie : ComponentBase
{
    [Parameter] public int Id { get; set; }

    private string GetFullId()
    {
        return $"movie-{Id}";
    }
}