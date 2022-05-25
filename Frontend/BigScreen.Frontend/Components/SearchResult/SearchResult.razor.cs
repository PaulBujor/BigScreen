using BigScreen.Core.Models.TMDb;
using BigScreen.Frontend.Components.SearchResult.ViewModel;
using BigScreen.Frontend.Core.Enums;
using Microsoft.AspNetCore.Components;

namespace BigScreen.Frontend.Components.SearchResult;

public partial class SearchResult : ComponentBase
{
    [Parameter]
    public SearchResultDto Result
    {
        get => ViewModel.Result;
        set => ViewModel.Result = value;
    }

    [CascadingParameter]
    public SearchFilter FilterContext
    {
        get => ViewModel.FilterContext;
        set => ViewModel.FilterContext = value;
    }

    [Inject]
    public ISearchResultViewModel ViewModel { get; set; } = null!;

    // Workaround
    // Weird issue that has deep root causes in Blazor
    protected override bool ShouldRender()
    {
        if (FilterContext == SearchFilter.All && Result.Type is null)
        {
            return false;
        }

        return true;
    }
}