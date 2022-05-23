using BigScreen.SDK.WebAPI.Core;

namespace BigScreen.Core.Models.BigScreen;

public class TopListDto : BaseDto
{
    public CachedUserDto? Owner { get; set; }
    public bool? IsPrivate { get; set; }
    public ICollection<CachedMovieDto>? Movies { get; set; }
}