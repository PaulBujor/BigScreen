using System.Runtime.Serialization;
using BigScreen.SDK.WebAPI.Core;
using BigScreen.SDK.WebAPI.Core.Attributes;
using Microsoft.OData.ModelBuilder;

namespace BigScreen.Core.Models.BigScreen;

[DataContract]
[EdmCollection("Comments")]
public class CommentDto : BaseDto
{
    [DataMember] public string? ForMedia { get; set; }

    [AutoExpand] [DataMember] public CachedUserDto? ByUser { get; set; }

    [DataMember] public string? ReplyTo { get; set; }

    [DataMember] public string? Text { get; set; }

    public static CommentDto GetDefaultEmptyState(string mediaId, string? commentId = "-1")
    {
        return new CommentDto
        {
            ForMedia = mediaId,
            ReplyTo = commentId,
            Text = ""
        };
    }
}