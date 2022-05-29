using BigScreen.Core.Models.BigScreen;
using BigScreen.Frontend.Client.Handlers.Interfaces;

namespace BigScreen.Frontend.Components.Discussion.ViewModel;

public class DiscussionViewModel : IDiscussionViewModel
{
    private readonly IDiscussionHandler _discussionHandler;

    private Action? _announceRootStateHasChanged;

    private ICollection<CommentDto>? _comments;

    private string? _mediaId;

    public DiscussionViewModel(IDiscussionHandler discussionHandler)
    {
        _discussionHandler = discussionHandler;
    }

    public async Task InitializeAsync(string mediaId)
    {
        if (mediaId != _mediaId)
        {
            _mediaId = mediaId;
            _comments = await _discussionHandler.GetComments(_mediaId) as ICollection<CommentDto>;
        }
    }

    public void AddListener(Action action)
    {
        _announceRootStateHasChanged += action;
    }

    public IEnumerable<CommentDto> GetComments(string? replyTo = null)
    {
        return _comments?.Where(c => c.ReplyTo == replyTo).ToList() ?? new List<CommentDto>();
    }

    public async Task PostCommentAsync(CommentDto comment)
    {
        _comments?.Add(await _discussionHandler.PostCommentAsync(comment));
        _announceRootStateHasChanged?.Invoke();
    }
}