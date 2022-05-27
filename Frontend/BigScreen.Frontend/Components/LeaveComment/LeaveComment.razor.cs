using BigScreen.Core.Models.BigScreen;
using BigScreen.Frontend.Components.Discussion.ViewModel;
using Microsoft.AspNetCore.Components;

namespace BigScreen.Frontend.Components.LeaveComment;

public partial class LeaveComment : ComponentBase
{
    private CommentDto _comment = null!;

    [Inject] public IDiscussionViewModel ViewModel { get; set; } = null!;

    [Parameter] public string MediaId { get; set; } = null!;

    protected override void OnInitialized()
    {
        _comment = CommentDto.GetDefaultEmptyState(MediaId);
        _comment.ByUser = new CachedUserDto {Username = "LIL POOP"};
    }

    private async Task PostCommentAsync()
    {
        await ViewModel.PostCommentAsync(_comment);

        _comment = CommentDto.GetDefaultEmptyState(MediaId);
        _comment.ByUser = new CachedUserDto {Username = "LIL POOP"};
    }
}