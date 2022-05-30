using Microsoft.AspNetCore.Components;

namespace BigScreen.Frontend.Components.DetailsPageLayout;

public partial class DetailsPageLayout : ComponentBase
{
    [Parameter]
    public RenderFragment? BannerContent { get; set; }

    [Parameter]
    public RenderFragment? MainContent { get; set; }

    [Parameter]
    public RenderFragment? SideContent { get; set; }
}