using BigScreen.Core.Models.BigScreen;

namespace BigScreen.Frontend.Components.Discussion.ViewModel;

public interface IDiscussionViewModel
{
    Action? OnRootStateHasChanged { get; set; }
    Task InitializeAsync(string mediaId);
    IEnumerable<CommentDto> GetComments(string? replyTo = null);
    Task PostCommentAsync(CommentDto comment);
}