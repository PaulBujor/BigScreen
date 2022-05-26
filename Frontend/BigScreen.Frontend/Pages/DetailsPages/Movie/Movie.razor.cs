using BigScreen.Frontend.Components.MediaDetailsPageLayout.Models;
using Microsoft.AspNetCore.Components;

namespace BigScreen.Frontend.Pages.DetailsPages.Movie;

public partial class Movie : ComponentBase
{
    [Parameter]
    public int Id { get; set; }

    public MediaModel GetMedia()
    {
        return new MediaModel("https://image.tmdb.org/t/p/w300/6JjfSchsU6daXk2AKX8EEBjO3Fm.jpg", "Morbius",
            DateOnly.Parse("05/14/2022"), new string[] { "Action", "Science Fiction", "Fantasy" },
            TimeSpan.FromMinutes(104), "A new Marvel legend arrives.",
            "Dangerously ill with a rare blood disorder, and determined to save others suffering his same fate, Dr. Michael Morbius attempts a desperate gamble. What at first appears to be a radical success soon reveals itself to be a remedy potentially worse than the disease.",
            true, 6.3, null, null);
    }
}