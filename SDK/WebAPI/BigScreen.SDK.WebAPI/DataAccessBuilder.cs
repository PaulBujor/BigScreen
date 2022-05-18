using BigScreen.SDK.DataAccess.Core;
using BigScreen.SDK.WebAPI.Core;
using Microsoft.Extensions.DependencyInjection;

namespace BigScreen.SDK.WebAPI;

public class DataAccessBuilder : IDataAccessBuilder
{
    private IServiceCollection _services;

    public DataAccessBuilder(IServiceCollection services)
    {
        _services = services;
    }

    public void Build()
    {
        
    }

    public IDataAccessBuilder Add<TDto, TDbEntry>() where TDto : BaseDto where TDbEntry : BaseDbEntry
    {
        _services.AddScoped<IDataAccess<TDto>, DataAccess<TDto, TDbEntry>>();
        return this;
    }
}