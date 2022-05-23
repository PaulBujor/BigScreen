using BigScreen.SDK.DataAccess.Core;
using BigScreen.SDK.DataAccess.Core.Attributes;

namespace BigScreen.Backend.Models;

[DbContainer(PartitionKey = nameof(ForMovie))]
public class CommentDbEntry : BaseDbEntry
{
    public string? ForMovie { get; set; }
    public CachedUserDbo? ByUser { get; set; }
    public string? ReplyTo { get; set; }
    public string? Text { get; set; }
}