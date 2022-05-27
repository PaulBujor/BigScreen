using BigScreen.Core.Models.BigScreen;
using BigScreen.Frontend.Components.Discussion.ViewModel;
using Microsoft.AspNetCore.Components;

namespace BigScreen.Frontend.Components.CommentCard;

public partial class CommentCard : ComponentBase
{
    private List<CommentDto> _replies = new();

    private CommentDto _reply = null!;

    private bool _showReplyComponent = false;

    [Inject] public IDiscussionViewModel ViewModel { get; set; } = null!;

    [Parameter] public string MediaId { get; set; } = null!;

    [Parameter] public CommentDto Comment { get; set; } = null!;

    protected override void OnInitialized()
    {
        _reply = CommentDto.GetDefaultEmptyState(MediaId, Comment.Id);
        _reply.ByUser = new CachedUserDto {Username = "LIL POOP"};
        CacheReplies();
        ViewModel.AddListener(() =>
        {
            CacheReplies();
            StateHasChanged();
        });
    }

    private void CacheReplies()
    {
        _replies = ViewModel.GetComments(Comment.Id);
    }

    private IEnumerable<CommentDto> GetReplies()
    {
        return _replies;
    }

    private void ToggleReply()
    {
        _showReplyComponent = !_showReplyComponent;
        _reply = CommentDto.GetDefaultEmptyState(MediaId, Comment.Id);
        _reply.ByUser = new CachedUserDto {Username = "LIL POOP"};
    }

    private async Task PostReply()
    {
        await ViewModel.PostCommentAsync(_reply);
        ToggleReply();
    }
}