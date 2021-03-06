using BigScreen.Frontend.Pages.GeneralPages.Movies.ViewModel;
using Microsoft.AspNetCore.Components;

namespace BigScreen.Frontend.Pages.GeneralPages.Movies;

public partial class Movies : ComponentBase
{
    [Inject]
    public IMoviesViewModel ViewModel { get; set; } = null!;

    protected override async Task OnInitializedAsync()
    {
        await ViewModel.CallSearch();
    }
}