using AutoMapper;
using BigScreen.SDK.DataAccess.Core;

namespace BigScreen.SDK.WebAPI.Core;

public class BaseProfile<TDto, TDbEntry> : Profile where TDto : BaseDto where TDbEntry : BaseDbEntry
{
    protected BaseProfile()
    {
        CreateMap<TDto, TDbEntry>().ReverseMap();
    }
}