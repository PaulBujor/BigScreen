using BigScreen.Core.Models.BigScreen;
using BigScreen.Frontend.Components.Discussion.ViewModel;
using Microsoft.AspNetCore.Components;

namespace BigScreen.Frontend.Components.CommentCard;

public partial class CommentCard : ComponentBase
{
    private IEnumerable<CommentDto> _replies = new List<CommentDto>();

    private CommentDto _reply = null!;

    private bool _showReplyComponent = false;

    [Inject] public IDiscussionViewModel ViewModel { get; set; } = null!;

    [Parameter] public string MediaId { get; set; } = null!;

    [Parameter] public CommentDto Comment { get; set; } = null!;

    protected override async Task OnInitializedAsync()
    {
        await ViewModel.InitializeAsync(MediaId);
        _reply = CommentDto.GetDefaultEmptyState(MediaId, Comment.Id);
        CacheReplies();
        ViewModel.OnRootStateHasChanged += () =>
        {
            CacheReplies();
            StateHasChanged();
        };
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
        _reply = _reply =
            CommentDto.GetDefaultEmptyState(MediaId, Comment.Id);
    }

    private async Task PostReply()
    {
        if (string.IsNullOrEmpty(_reply.Text)) return;

        await ViewModel.PostCommentAsync(_reply);
        ToggleReply();
    }

    private string GetAccountUrl()
    {
        return $"account/{Comment.ByUser?.Id}";
    }
}