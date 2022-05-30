using System.Runtime.Serialization;
using BigScreen.SDK.WebAPI.Core;
using BigScreen.SDK.WebAPI.Core.Attributes;
using Microsoft.OData.ModelBuilder;

namespace BigScreen.Core.Models.BigScreen;

[DataContract]
[EdmCollection("Comments")]
public class CommentDto : BaseDto
{
    [DataMember] public string? ForMovie { get; set; }

    [AutoExpand] [DataMember] public CachedUserDto? ByUser { get; set; }

    [DataMember] public string? ReplyTo { get; set; }

    [DataMember] public string? Text { get; set; }

    public static CommentDto GetDefaultEmptyState(string? mediaId = null, string? commentId = "-1",
        CachedUserDto? byUser = null)
    {
        return new CommentDto
        {
            ForMovie = mediaId,
            ReplyTo = commentId,
            Text = "",
            ByUser = byUser
        };
    }
}