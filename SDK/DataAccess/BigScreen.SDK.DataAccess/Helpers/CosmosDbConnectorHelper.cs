using System.Reflection;
using BigScreen.SDK.DataAccess.Attributes;
using BigScreen.SDK.DataAccess.Core;

namespace BigScreen.SDK.DataAccess.Helpers;

internal static class CosmosDbConnectorHelper
{
    internal static string GetContainerId<TDb>() where TDb : BaseDbEntry
    {
        var dbContainerAttribute = typeof(TDb).GetCustomAttribute<DbContainerAttribute>();

        var containerId = string.IsNullOrWhiteSpace(dbContainerAttribute?.ContainerName)
            ? typeof(TDb).Name
            : dbContainerAttribute.ContainerName;

        return containerId;
    }
}