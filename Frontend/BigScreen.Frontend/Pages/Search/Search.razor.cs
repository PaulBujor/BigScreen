using BigScreen.Frontend.Pages.Search.ViewModel;
using Microsoft.AspNetCore.Components;

namespace BigScreen.Frontend.Pages.Search;

public partial class Search : ComponentBase
{
    [Parameter] public string? Query { get; set; }

    [Inject] public ISearchViewModel ViewModel { get; set; } = null!;

    protected override Task OnInitializedAsync()
    {
        if (!string.IsNullOrEmpty(Query))
        {
            ViewModel.SearchQuery = Query;
        }

        ViewModel.RefreshView += StateHasChanged;
        return base.OnInitializedAsync();
    }
}