using System.Runtime.Serialization;
using BigScreen.SDK.WebAPI.Core;

namespace BigScreen.Core.Models.BigScreen;

[DataContract]
public class CommentDto : BaseDto
{
    [DataMember(Name = "forMovie")] public string? ForMovie { get; set; }

    [DataMember(Name = "byUser")] public CachedUserDto? ByUser { get; set; }

    [DataMember(Name = "replyTo")] public string? ReplyTo { get; set; }

    [DataMember(Name = "text")] public string? Text { get; set; }

    public static CommentDto GetDefaultEmptyState(string? mediaId = null, string? commentId = "-1",
        CachedUserDto? byUser = null)
    {
        return new CommentDto
        {
            Id = Guid.NewGuid().ToString(),
            ForMovie = mediaId,
            ReplyTo = commentId,
            Text = "",
            ByUser = byUser
        };
    }
}