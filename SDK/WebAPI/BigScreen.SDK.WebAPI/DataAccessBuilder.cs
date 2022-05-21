using System.Reflection;
using BigScreen.SDK.DataAccess.Core;
using BigScreen.SDK.WebAPI.Abstractions;
using BigScreen.SDK.WebAPI.Core;
using Microsoft.Extensions.DependencyInjection;

namespace BigScreen.SDK.WebAPI;

public class DataAccessBuilder : IDataAccessBuilder
{
    private readonly ICollection<Type> _profiles;
    private readonly IServiceCollection _services;

    public DataAccessBuilder(IServiceCollection services)
    {
        _services = services;
        _profiles = new HashSet<Type>();
    }

    public void Build()
    {
        foreach (var type in Assembly.GetCallingAssembly().GetTypes())
            try
            {
                if (type.BaseType?.GetGenericTypeDefinition() == typeof(BaseProfile<,>)) _profiles.Add(type);
            }
            catch (InvalidOperationException)
            {
                //ignored
            }

        _services.AddAutoMapper(_profiles.ToArray());
    }

    public IDataAccessBuilder Add<TDto, TDbEntry>() where TDto : BaseDto where TDbEntry : BaseDbEntry
    {
        _services.AddScoped<IDataAccess<TDto>, DataAccess<TDto, TDbEntry>>();
        return this;
    }
}