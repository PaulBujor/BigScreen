using BigScreen.SDK.DataAccess.Core;

namespace BigScreen.Backend.Models;

public class CachedUserDbo : BaseDbObject
{
    public string? Username { get; set; }
}