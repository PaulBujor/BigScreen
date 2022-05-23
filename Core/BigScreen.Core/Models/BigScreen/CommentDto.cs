using BigScreen.SDK.WebAPI.Core;

namespace BigScreen.Core.Models.BigScreen;

public class CommentDto : BaseDto
{
    public string? ForMovie { get; set; }
    public CachedUserDto? ByUser { get; set; }
    public string? ReplyTo { get; set; }
    public string? Text { get; set; }
}