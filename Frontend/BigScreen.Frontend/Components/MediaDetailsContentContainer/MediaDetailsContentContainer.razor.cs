using Microsoft.AspNetCore.Components;

namespace BigScreen.Frontend.Components.MediaDetailsContentContainer;

public partial class MediaDetailsContentContainer : ComponentBase
{
    [Parameter]
    public string? Name { get; set; }

    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    [Parameter]
    public bool IsScrollable { get; set; }

    private (string Container, string Wrapper) GetContentClasses()
    {
        var wrapper = "d-flex py-3 ";
        var container = string.Empty;
        if (IsScrollable)
        {
            container = "content-container";
            wrapper += "flex-nowrap pl-2 pr-10 content-wrapper gap-3 overflow-x-scroll";
        }
        else
        {
            wrapper += "flex-column flex-wrap";
        }

        return (container, wrapper);
    }
}