using BigScreen.Core.Models.BigScreen;
using BigScreen.Frontend.Client.Handlers.Interfaces;
using BigScreen.Frontend.Client.Security;

namespace BigScreen.Frontend.Components.Discussion.ViewModel;

public class DiscussionViewModel : IDiscussionViewModel
{
    private readonly IDiscussionHandler _discussionHandler;

    private readonly UserState _userState;

    private ICollection<CommentDto>? _comments;

    private string? _mediaId;

    public DiscussionViewModel(IDiscussionHandler discussionHandler, UserState userState)
    {
        _discussionHandler = discussionHandler;
        _userState = userState;
    }

    public Action? OnRootStateHasChanged { get; set; }

    public async Task InitializeAsync(string mediaId)
    {
        if (mediaId != _mediaId)
        {
            _mediaId = mediaId;
            _comments = await _discussionHandler.GetComments(_mediaId) as ICollection<CommentDto>;
        }
    }

    public IEnumerable<CommentDto> GetComments(string? replyTo = null)
    {
        return _comments?.Where(c => c.ReplyTo == replyTo).ToList() ?? new List<CommentDto>();
    }

    public async Task PostCommentAsync(CommentDto comment)
    {
        var addedComment = await _discussionHandler.PostCommentAsync(comment);
        _comments ??= new List<CommentDto>();
        _comments.Add(addedComment);
        OnRootStateHasChanged?.Invoke();
    }
}