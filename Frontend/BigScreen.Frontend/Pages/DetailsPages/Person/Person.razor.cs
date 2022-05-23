namespace BigScreen.Frontend.Pages.DetailsPages.Person;

using Microsoft.AspNetCore.Components;

public partial class Person : ComponentBase
{
    [Parameter] public int Id { get; set; }
}