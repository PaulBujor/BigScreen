using AutoMapper;
using BigScreen.SDK.DataAccess.Core;
using BigScreen.SDK.WebAPI.Core;

namespace BigScreen.SDK.WebAPI;

public class BaseProfile<TDto, TDbEntry> : Profile where TDto : BaseDto where TDbEntry : BaseDbEntry
{
    protected BaseProfile()
    {
        CreateMap<TDto, TDbEntry>().ReverseMap();
    }
}