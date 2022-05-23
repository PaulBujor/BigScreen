using BigScreen.SDK.DataAccess.Core;
using BigScreen.SDK.DataAccess.Core.Attributes;

namespace BigScreen.Backend.Models;

[DbContainer(PartitionKey = "owner/id")]
public class TopListDbEntry : BaseDbEntry
{
    public CachedUserDbo? Owner { get; set; }
    public bool? IsPrivate { get; set; }
    public ICollection<CachedMovieDbo>? Movies { get; set; }
}