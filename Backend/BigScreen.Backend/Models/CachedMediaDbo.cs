using BigScreen.SDK.DataAccess.Core;

namespace BigScreen.Backend.Models;

public class CachedMediaDbo : BaseDbObject
{
    public string? Name { get; set; }
    public string? ImageUrl { get; set; }
}