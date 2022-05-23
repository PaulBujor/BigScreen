using BigScreen.SDK.WebAPI.Core;

namespace BigScreen.Core.Models.BigScreen;

public class CachedMovieDto : BaseObject
{
    public string? Title { get; set; }
    public string? PosterImageUrl { get; set; }
}