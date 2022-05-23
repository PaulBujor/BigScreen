using BigScreen.Core.Models.BigScreen;
using BigScreen.SDK.WebAPI.Core;

namespace BigScreen.Backend.Models.Profiles;

public class CommentProfile : BaseProfile<CommentDto, CommentDbEntry>
{
    public CommentProfile()
    {
        CreateMap<CachedUserDto, CachedUserDbo>().ReverseMap();
    }
}