using BigScreen.Core.Models.BigScreen;
using BigScreen.Frontend.Client.Security;
using BigScreen.Frontend.Components.Discussion.ViewModel;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;

namespace BigScreen.Frontend.Components.LeaveComment;

public partial class LeaveComment : ComponentBase
{
    private CommentDto _comment = null!;

    [CascadingParameter]
    private Task<AuthenticationState> AuthenticationStateTask { get; set; } = null!;

    [Inject]
    public IDiscussionViewModel ViewModel { get; set; } = null!;

    [Parameter]
    public string MediaId { get; set; } = null!;

    protected override async Task OnInitializedAsync()
    {
        _comment = CommentDto.GetDefaultEmptyState(MediaId,
            byUser: (await AuthenticationStateTask).GetCachedUserData());
    }

    private async Task PostCommentAsync()
    {
        if (string.IsNullOrEmpty(_comment?.Text)) return;

        await ViewModel.PostCommentAsync(_comment);

        _comment = CommentDto.GetDefaultEmptyState(MediaId,
            byUser: (await AuthenticationStateTask).GetCachedUserData());
    }
}