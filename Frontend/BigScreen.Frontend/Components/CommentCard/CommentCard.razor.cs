using BigScreen.Core.Models.BigScreen;
using BigScreen.Frontend.Components.Discussion.ViewModel;
using BigScreen.Frontend.Security;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;

namespace BigScreen.Frontend.Components.CommentCard;

public partial class CommentCard : ComponentBase
{
    private List<CommentDto> _replies = new();

    private CommentDto _reply = null!;

    private bool _showReplyComponent = false;

    [CascadingParameter]
    private Task<AuthenticationState> AuthenticationStateTask { get; set; } = null!;

    [Inject]
    public IDiscussionViewModel ViewModel { get; set; } = null!;

    [Parameter]
    public string MediaId { get; set; } = null!;

    [Parameter]
    public CommentDto Comment { get; set; } = null!;

    protected override async Task OnInitializedAsync()
    {
        _reply = _reply =
            CommentDto.GetDefaultEmptyState(MediaId, Comment.Id, (await AuthenticationStateTask).GetUserData());
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

    private IEnumerable<CommentDto> GetReplies() => _replies;

    private async Task ToggleReply()
    {
        _showReplyComponent = !_showReplyComponent;
        _reply = _reply =
            CommentDto.GetDefaultEmptyState(MediaId, Comment.Id, (await AuthenticationStateTask).GetUserData());
    }

    private async Task PostReply()
    {
        await ViewModel.PostCommentAsync(_reply);
        await ToggleReply();
    }
}