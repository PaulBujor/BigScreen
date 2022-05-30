using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace BigScreen.Frontend.Components.ConfirmDelete;

public partial class ConfirmDelete : ComponentBase
{
    [Parameter]
    public string Title { get; set; } = null!;

    [Parameter]
    public string Id { get; set; } = null!;

    [CascadingParameter]
    private MudDialogInstance MudDialog { get; set; } = null!;

    private void Cancel()
    {
        MudDialog.Cancel();
    }

    private void Delete()
    {
        MudDialog.Close(DialogResult.Ok(Id));
    }
}