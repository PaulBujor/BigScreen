using BigScreen.Core.Models.BigScreen;

namespace BigScreen.Frontend.Client.Handlers.Interfaces;

public interface IDiscussionHandler
{
    Task<IEnumerable<CommentDto>> GetComments(string mediaId);
    Task<CommentDto> PostCommentAsync(CommentDto comment);
}