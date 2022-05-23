namespace BigScreen.Frontend.Pages.Home;

using Microsoft.AspNetCore.Components;
using ViewModel;

public partial class Home : ComponentBase
{
    [Inject] public IHomeViewModel ViewModel { get; set; } = null!;
}