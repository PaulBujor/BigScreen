using BigScreen.Frontend.Components.GeneralPageLayout.Models;
using BigScreen.Frontend.Components.GeneralPageLayout.ViewModel;
using BigScreen.Frontend.Core.Enums;
using Microsoft.AspNetCore.Components;

namespace BigScreen.Frontend.Components.GeneralPageLayout;

public partial class GeneralPageLayout : ComponentBase
{
    [Inject]
    public IGeneralPageLayoutViewModel ViewModel { get; set; }

    [Parameter]
    public SortFilter[]? SortFilterOptions { get; set; }

    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    [Parameter]
    public int? PaginationCount { get; set; }

    [Parameter]
    public EventCallback<SearchContext> SearchContextChanged
    {
        get => ViewModel.SearchContextChanged;
        set => ViewModel.SearchContextChanged = value;
    }

    [Parameter]
    public bool HasSearch
    {
        get => throw new NotImplementedException();
        set => throw new NotImplementedException();
    }

    protected override void OnParametersSet()
    {
        var sortFilterOptionsMissing = SortFilterOptions is null || !SortFilterOptions.Any();
        var childContentMissing = ChildContent is null;
        var paginationCountMissing = PaginationCount is null;
        var searchContextChangedMissing = !SearchContextChanged.HasDelegate;
        var mandatoryParametersMissing = sortFilterOptionsMissing || childContentMissing || paginationCountMissing ||
                                         searchContextChangedMissing;
        if (mandatoryParametersMissing)
        {
            throw new ArgumentException("Mandatory parameters not provided for GeneralPageLayout component.");
        }

        base.OnParametersSet();
    }
}