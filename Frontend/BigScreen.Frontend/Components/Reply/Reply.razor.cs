using BigScreen.Core.Models.BigScreen;
using Microsoft.AspNetCore.Components;

namespace BigScreen.Frontend.Components.Reply;

public partial class Reply : ComponentBase
{
    [Parameter] public CommentDto Comment { get; set; } = null!;

    private string GetAccountUrl()
    {
        return $"account/{Comment.ByUser?.Id}";
    }
}