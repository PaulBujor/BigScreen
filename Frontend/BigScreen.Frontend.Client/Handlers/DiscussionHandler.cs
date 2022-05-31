using BigScreen.Core.Models.BigScreen;
using BigScreen.Frontend.Client.Handlers.Interfaces;
using BigScreen.Frontend.Client.Security;
using BigScreen.SDK.Client.Abstractions;

namespace BigScreen.Frontend.Client.Handlers;

public class DiscussionHandler : IDiscussionHandler
{
    private readonly IODataClient<CommentDto> _handler;
    private readonly UserState _userState;

    public DiscussionHandler(IODataClient<CommentDto> handler, UserState userState)
    {
        _handler = handler;
        _userState = userState;
    }

    public async Task<IEnumerable<CommentDto>> GetComments(string mediaId)
    {
        return (await _handler.GetAllAsync($"?$filter=ForMedia eq '{mediaId}'"))!;
    }

    public async Task<CommentDto> PostCommentAsync(CommentDto comment)
    {
        comment.ByUser = _userState.User!.GetCachedVersion();
        return (await _handler.PostAsync(comment))!;
    }
}