using BigScreen.SDK.DataAccess.Core;
using BigScreen.SDK.DataAccess.Core.Attributes;

namespace BigScreen.Backend.Models;

[DbContainer(PartitionKey = nameof(ForMedia))]
public class CommentDbEntry : BaseDbEntry
{
    public string? ForMedia { get; set; }
    public CachedUserDbo? ByUser { get; set; }
    public string? ReplyTo { get; set; }
    public string? Text { get; set; }
}