using BigScreen.Frontend.Pages.GeneralPages.People.ViewModel;
using Microsoft.AspNetCore.Components;

namespace BigScreen.Frontend.Pages.GeneralPages.People;

public partial class People : ComponentBase
{
    [Inject]
    public IPeopleViewModel ViewModel { get; set; } = null!;

    protected override async Task OnInitializedAsync()
    {
        await ViewModel.CallSearch();
    }
}