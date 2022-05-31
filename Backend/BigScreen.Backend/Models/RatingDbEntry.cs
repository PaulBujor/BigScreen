using BigScreen.SDK.DataAccess.Core;
using BigScreen.SDK.DataAccess.Core.Attributes;

namespace BigScreen.Backend.Models;

[DbContainer(PartitionKey = nameof(ForMedia))]
public class RatingDbEntry : BaseDbEntry
{
    public string? ForMedia { get; set; }
    public string? ByUser { get; set; }
    public double? Score { get; set; }
}