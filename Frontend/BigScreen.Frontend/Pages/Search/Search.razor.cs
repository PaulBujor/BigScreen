using BigScreen.Frontend.Pages.Search.ViewModel;
using Microsoft.AspNetCore.Components;

namespace BigScreen.Frontend.Pages.Search;

public partial class Search : ComponentBase, IDisposable
{
    [Parameter]
    public string? Query { get; set; }

    [Inject]
    public ISearchViewModel ViewModel { get; set; } = null!;

    public void Dispose()
    {
        ViewModel.DisposeViewModel();
#pragma warning disable CS8601
        ViewModel.RefreshView -= StateHasChanged;
#pragma warning restore CS8601
    }

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