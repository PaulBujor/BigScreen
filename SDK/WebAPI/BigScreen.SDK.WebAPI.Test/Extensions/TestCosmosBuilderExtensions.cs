using BigScreen.SDK.DataAccess.Abstractions;
using BigScreen.SDK.DataAccess.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace BigScreen.SDK.WebAPI.Test.Extensions;

internal static class TestCosmosBuilderExtensions
{
    public const string HttpsLocalhost = "https://localhost:8081";

    public const string AccessKey =
        "C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==";

    public const string DatabaseName = "BigScreenTest";

    public static ICosmosDbBuilder AddLocalCosmosDb(this IServiceCollection services)
    {
        return services.AddCosmosDb(HttpsLocalhost, AccessKey, DatabaseName);
    }
}