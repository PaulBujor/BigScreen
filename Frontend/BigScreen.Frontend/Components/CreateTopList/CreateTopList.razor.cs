using BigScreen.Frontend.Client.Handlers.Interfaces;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace BigScreen.Frontend.Components.CreateTopList;

public partial class CreateTopList : ComponentBase
{
    private string _topListName = "";

    [CascadingParameter] private MudDialogInstance MudDialog { get; set; }

    [Inject] private ITopListHandler TopListHandler { get; set; } = null!;

    private async Task CreateNewTopList()
    {
        if (!string.IsNullOrWhiteSpace(_topListName))
        {
            await TopListHandler.CreateTopListAsync(_topListName);
            Close();
        }
    }

    private void Close()
    {
        MudDialog.Close();
    }
}