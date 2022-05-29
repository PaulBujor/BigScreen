using BigScreen.Frontend.Pages.Home.ViewModel;
using Microsoft.AspNetCore.Components;

namespace BigScreen.Frontend.Pages.Home;

public partial class Home : ComponentBase
{
    [Inject]
    public IHomeViewModel ViewModel { get; set; } = null!;
}