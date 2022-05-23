using BigScreen.Core.Models.BigScreen;
using BigScreen.SDK.WebAPI.Core;

namespace BigScreen.Backend.Models.Profiles;

public class TopListProfile : BaseProfile<TopListDto, TopListDbEntry>
{
    public TopListProfile()
    {
        CreateMap<CachedMovieDto, CachedMovieDbo>().ReverseMap();
        CreateMap<CachedUserDto, CachedUserDbo>().ReverseMap();
    }
}