using BigScreen.Frontend.Pages.DetailsPages.TvShow.ViewModel;
using Microsoft.AspNetCore.Components;

namespace BigScreen.Frontend.Pages.DetailsPages.TvShow;

public partial class TvShow : ComponentBase
{
    private bool _isLoaded;

    [Parameter]
    public int Id
    {
        get => ViewModel.Id;
        set => ViewModel.Id = value;
    }

    [Inject]
    public ITvShowViewModel ViewModel { get; set; } = null!;

    protected override async Task OnParametersSetAsync()
    {
        _isLoaded = false;
        await ViewModel.GetMediaDetails();
        _isLoaded = true;
    }
}