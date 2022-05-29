using BigScreen.Frontend.Pages.DetailsPages.TvShow.ViewModel;
using Microsoft.AspNetCore.Components;

namespace BigScreen.Frontend.Pages.DetailsPages.TvShow;

public partial class TvShow : ComponentBase
{
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
        await ViewModel.GetTvShowDetails();
        ViewModel.MediaModel = ViewModel.GetMediaModel();
    }
}