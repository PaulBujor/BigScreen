using BigScreen.Frontend.Pages.Search.ViewModel;
using Microsoft.AspNetCore.Components;

namespace BigScreen.Frontend.Pages.Search;

public partial class Search : ComponentBase
{
    [Parameter]
    public string? Query { get; set; }

    [Inject]
    public ISearchViewModel ViewModel { get; set; } = null!;
    
    protected override void OnAfterRender(bool firstRender)
    {
        if (!string.IsNullOrEmpty(Query) && firstRender)
        {
            ViewModel.LayoutInstance?.SetSearchQuery(Query);
        }

        base.OnAfterRender(firstRender);
    }
}