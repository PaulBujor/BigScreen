using BigScreen.SDK.DataAccess.Core;
using BigScreen.SDK.WebAPI.Core;

namespace BigScreen.SDK.WebAPI;

public class DataAccess<TDto,TDbEntry> : IDataAccess<TDto> where TDto: BaseDto where TDbEntry: BaseDbEntry
{
    
}