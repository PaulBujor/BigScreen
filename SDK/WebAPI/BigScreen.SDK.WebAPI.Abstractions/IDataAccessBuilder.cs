using BigScreen.SDK.DataAccess.Core;
using BigScreen.SDK.WebAPI.Core;

namespace BigScreen.SDK.WebAPI.Abstractions;

public interface IDataAccessBuilder
{
    void Build();
    IDataAccessBuilder Add<TDto, TDbEntry>() where TDto : BaseDto where TDbEntry : BaseDbEntry;
}