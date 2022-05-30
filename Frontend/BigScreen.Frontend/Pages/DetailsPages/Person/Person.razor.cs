using BigScreen.Frontend.Pages.DetailsPages.Person.ViewModel;
using Microsoft.AspNetCore.Components;

namespace BigScreen.Frontend.Pages.DetailsPages.Person;

public partial class Person : ComponentBase
{
    [Parameter]
    public int Id
    {
        get => ViewModel.Id;
        set => ViewModel.Id = value;
    }

    [Inject]
    public IPersonViewModel ViewModel { get; set; } = null!;

    protected override async Task OnParametersSetAsync()
    {
        await ViewModel.GetPersonDetails();
        ViewModel.GetCrewByDepartment();
    }
}