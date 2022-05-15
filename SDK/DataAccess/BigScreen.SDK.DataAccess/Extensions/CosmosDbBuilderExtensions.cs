using BigScreen.SDK.DataAccess.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace BigScreen.SDK.DataAccess.Extensions;

internal static class CosmosDbBuilderExtensions
{
    /// <summary>
    ///     Creates a Cosmos Connector builder
    /// </summary>
    /// <param name="services">Service collection from builder</param>
    /// <param name="endpoint">Endpoint of the Cosmos Db Resource</param>
    /// <param name="accessKey">Access key of the Cosmos Db Resource</param>
    /// <param name="databaseName">Database ID within the Cosmos Db Resource</param>
    /// <returns>
    ///     <see cref="ICosmosDbBuilder" />
    /// </returns>
    public static ICosmosDbBuilder AddCosmosDb(this IServiceCollection services, string endpoint, string accessKey,
        string databaseName)
    {
        return new CosmosDbBuilder(endpoint, accessKey, databaseName, services);
    }
}