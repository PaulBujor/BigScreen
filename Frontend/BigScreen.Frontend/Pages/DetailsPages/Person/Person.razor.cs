using Microsoft.AspNetCore.Components;

namespace BigScreen.Frontend.Pages.DetailsPages.Person;

public partial class Person : ComponentBase
{
    [Parameter]
    public int Id { get; set; }
}