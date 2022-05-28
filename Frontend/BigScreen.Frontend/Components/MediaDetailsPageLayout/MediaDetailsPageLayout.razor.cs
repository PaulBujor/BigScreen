using BigScreen.Frontend.Components.MediaDetailsPageLayout.Models;
using BigScreen.Frontend.Components.MediaDetailsPageLayout.ViewModel;
using Microsoft.AspNetCore.Components;

namespace BigScreen.Frontend.Components.MediaDetailsPageLayout;

public partial class MediaDetailsPageLayout : ComponentBase
{
    [Inject]
    public IMediaDetailsPageLayoutViewModel ViewModel { get; set; } = null!;

    [Parameter]
    public MediaModel? MediaModel
    {
        get => ViewModel.MediaModel;
        set => ViewModel.MediaModel = value!;
    }

    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    protected override void OnParametersSet()
    {
        var infoMissing = MediaModel is null;
        var mandatoryParamsMissing = infoMissing;

        if (mandatoryParamsMissing)
        {
            // throw new ArgumentException("Mandatory parameters not provided");
        }

        base.OnParametersSet();
    }
}