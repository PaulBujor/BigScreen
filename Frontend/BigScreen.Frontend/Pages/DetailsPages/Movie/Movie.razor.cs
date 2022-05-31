using BigScreen.Frontend.Pages.DetailsPages.Movie.ViewModel;
using Microsoft.AspNetCore.Components;

namespace BigScreen.Frontend.Pages.DetailsPages.Movie;

public partial class Movie : ComponentBase
{
    private bool _isLoaded;

    [Parameter]
    public int Id
    {
        get => ViewModel.Id;
        set => ViewModel.Id = value;
    }

    [Inject]
    public IMovieViewModel ViewModel { get; set; } = null!;

    protected override async Task OnParametersSetAsync()
    {
        _isLoaded = false;
        await ViewModel.GetMediaDetails();
        _isLoaded = true;
    }
}