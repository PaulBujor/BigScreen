using BigScreen.Core.Models.BigScreen;
using BigScreen.SDK.WebAPI.Core;

namespace BigScreen.Backend.Models.Profiles;

public class UserProfile : BaseProfile<UserDto, UserDbEntry>
{
    public UserProfile()
    {
        CreateMap<CachedTopListDto, CachedTopListDbo>().ReverseMap();
        CreateMap<CachedUserDto, CachedUserDbo>().ReverseMap();
    }
}