namespace BigScreen.Frontend.Components.SearchResult;

using BigScreen.Core.Models.TMDb;
using Core.Enums;
using Microsoft.AspNetCore.Components;
using ViewModel;

public partial class SearchResult : ComponentBase
{
    [Parameter]
    public SearchResultDto Result
    {
        get => ViewModel.Result;
        set => ViewModel.Result = value;
    }

    [Parameter]
    public SearchFilter FilterContext
    {
        get => ViewModel.FilterContext;
        set => ViewModel.FilterContext = value;
    }

    [Inject] public ISearchResultViewModel ViewModel { get; set; } = null!;
}