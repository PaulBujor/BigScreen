namespace BigScreen.Frontend.Pages.Home.ViewModel;

using Microsoft.AspNetCore.Components;

public class HomeViewModel : IHomeViewModel
{
    private readonly NavigationManager _navigationManager;

    public HomeViewModel(NavigationManager navigationManager)
    {
        _navigationManager = navigationManager;
    }


    public void OnValueChanged(string query)
    {
        if (!string.IsNullOrEmpty(query))
        {
            _navigationManager.NavigateTo($"/search/{query}");
        }
    }
}