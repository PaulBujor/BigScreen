using BigScreen.SDK.DataAccess.Core;
using BigScreen.SDK.DataAccess.Core.Attributes;

namespace BigScreen.Backend.Models;

[DbContainer(PartitionKey = "Owner/id")]
public class TopListDbEntry : BaseDbEntry
{
    public string? Title { get; set; }
    public CachedUserDbo? Owner { get; set; }
    public bool? IsPrivate { get; set; }
    public ICollection<CachedMediaDbo>? MediaItems { get; set; }
}