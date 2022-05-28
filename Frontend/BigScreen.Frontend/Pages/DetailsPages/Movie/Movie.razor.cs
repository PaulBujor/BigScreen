using BigScreen.Frontend.Pages.DetailsPages.Movie.ViewModel;
using Microsoft.AspNetCore.Components;

namespace BigScreen.Frontend.Pages.DetailsPages.Movie;

public partial class Movie : ComponentBase
{
    [Parameter]
    public int Id
    {
        get => ViewModel.Id;
        set => ViewModel.Id = value;
    }

    [Inject]
    public IMovieViewModel ViewModel { get; set; } = null!;

    protected override async Task OnParametersSetAsync() => await ViewModel.GetMovieDetails();

    private string GetFullId()
    {
        return $"movie-{Id}";
    }
}