using BigScreen.SDK.DataAccess.Core;
using BigScreen.SDK.DataAccess.Core.Attributes;

namespace BigScreen.Backend.Models;

[DbContainer(PartitionKey = nameof(ForMovie))]
public class RatingDbEntry : BaseDbEntry
{
    public string? ForMovie { get; set; }
    public string? ByUser { get; set; }
    public int? Score { get; set; }
}