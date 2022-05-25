using BigScreen.Frontend.Pages.GeneralPages.TvShows.ViewModel;
using Microsoft.AspNetCore.Components;

namespace BigScreen.Frontend.Pages.GeneralPages.TvShows;

public partial class TvShows : ComponentBase
{
    [Inject]
    public ITvShowsViewModel ViewModel { get; set; } = null!;

    protected override async Task OnInitializedAsync()
    {
        await ViewModel.CallSearch();
    }
}