using BigScreen.Core.Models.BigScreen;
using BigScreen.Frontend.Components.Discussion.ViewModel;
using Microsoft.AspNetCore.Components;

namespace BigScreen.Frontend.Components.Discussion;

public partial class Discussion : ComponentBase
{
    private bool _isReplying;

    [Inject] public IDiscussionViewModel ViewModel { get; set; } = null!;

    [Parameter] public string MediaId { get; set; } = null!;

    [Parameter] public string? CommentId { get; set; }

    protected override async Task OnInitializedAsync()
    {
        _isReplying = CommentId == null;
        await ViewModel.InitializeAsync(MediaId);
        ViewModel.OnRootStateHasChanged += StateHasChanged;
    }

    private IEnumerable<CommentDto> GetComments(string? commentId = null)
    {
        return ViewModel.GetComments(commentId);
    }
}