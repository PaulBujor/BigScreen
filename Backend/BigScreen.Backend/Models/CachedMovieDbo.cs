using BigScreen.SDK.DataAccess.Core;

namespace BigScreen.Backend.Models;

public class CachedMovieDbo : BaseDbObject
{
    public string? Title { get; set; }
    public string? PosterImageUrl { get; set; }
}