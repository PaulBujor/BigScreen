using System.Runtime.Serialization;
using BigScreen.SDK.WebAPI.Core;
using BigScreen.SDK.WebAPI.Core.Attributes;

namespace BigScreen.Core.Models.BigScreen;

[DataContract]
[EdmCollection("Comments")]
public class CommentDto : BaseDto
{
    [DataMember(Name = "forMovie")]
    public string? ForMovie { get; set; }

    [DataMember(Name = "byUser")]
    public CachedUserDto? ByUser { get; set; }

    [DataMember(Name = "replyTo")]
    public string? ReplyTo { get; set; }

    [DataMember(Name = "text")]
    public string? Text { get; set; }

    public static CommentDto GetDefaultEmptyState(string? mediaId = null, string? commentId = "-1",
        CachedUserDto? byUser = null) => new CommentDto
    {
        ForMovie = mediaId,
        ReplyTo = commentId,
        Text = "",
        ByUser = byUser
    };
}