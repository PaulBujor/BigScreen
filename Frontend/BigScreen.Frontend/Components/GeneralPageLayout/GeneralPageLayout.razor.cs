using BigScreen.Frontend.Components.GeneralPageLayout.Models;
using BigScreen.Frontend.Components.GeneralPageLayout.ViewModel;
using BigScreen.Frontend.Core.Enums;
using Microsoft.AspNetCore.Components;

namespace BigScreen.Frontend.Components.GeneralPageLayout;

public partial class GeneralPageLayout<TFilter> : ComponentBase
{
    [Inject]
    public IGeneralPageLayoutViewModel<TFilter> ViewModel { get; set; }

    [Parameter]
    public TFilter[]? FilterOptions { get; set; }

    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    [Parameter]
    public int? PaginationCount { get; set; }

    [Parameter]
    public EventCallback<SearchContext<TFilter>> SearchContextChanged
    {
        get => ViewModel.SearchContextChanged;
        set => ViewModel.SearchContextChanged = value;
    }

    [Parameter]
    public bool HasSearch
    {
        get => ViewModel.HasSearch;
        set => ViewModel.HasSearch = value;
    }

    protected override void OnParametersSet()
    {
        var sortFilterOptionsMissing = FilterOptions is null || !FilterOptions.Any();
        var childContentMissing = ChildContent is null;
        var paginationCountMissing = PaginationCount is null;
        var searchContextChangedMissing = !SearchContextChanged.HasDelegate;
        var mandatoryParametersMissing = sortFilterOptionsMissing || childContentMissing || searchContextChangedMissing || paginationCountMissing;
        if (mandatoryParametersMissing)
        {
            throw new ArgumentException("Mandatory parameters not provided for GeneralPageLayout component.");
        }

        base.OnParametersSet();
    }

    public void SetSearchQuery(string query)
    {
        ViewModel.SearchQuery = query;
    }
}