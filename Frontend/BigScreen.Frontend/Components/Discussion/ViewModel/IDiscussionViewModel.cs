using BigScreen.Core.Models.BigScreen;

namespace BigScreen.Frontend.Components.Discussion.ViewModel;

public interface IDiscussionViewModel
{
    Task InitializeAsync(string mediaId);
    List<CommentDto> GetComments(string? replyTo = null);
    Task PostCommentAsync(CommentDto comment);
    void AddListener(Action action);
}