using Microsoft.Extensions.DependencyInjection;

namespace BigScreen.SDK.WebAPI.Extensions;

public static class DataAccessBuilderExtensions
{
    public static IDataAccessBuilder AddDataAccess(this IServiceCollection services)
    {
        return new DataAccessBuilder(services);
    }
}