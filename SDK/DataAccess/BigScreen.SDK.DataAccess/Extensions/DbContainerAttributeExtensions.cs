using System.Linq.Expressions;
using System.Reflection;
using BigScreen.SDK.DataAccess.Core;
using BigScreen.SDK.DataAccess.Core.Attributes;

namespace BigScreen.SDK.DataAccess.Extensions;

internal static class DbContainerAttributeExtensions
{
    public static string GetContainerId(this Type type)
    {
        var dbContainerAttribute = type.GetDbContainerAttribute();

        var containerId = string.IsNullOrWhiteSpace(dbContainerAttribute?.ContainerName)
            ? type.Name
            : dbContainerAttribute.ContainerName;

        return containerId;
    }

    public static string GetPartitionKeyDefinition(this Type type)
    {
        var dbContainerAttribute = type.GetDbContainerAttribute();

        if (string.IsNullOrWhiteSpace(dbContainerAttribute.PartitionKey))
            throw new InvalidOperationException(
                $"{type.FullName} does not have a Partition Key set in the DbContainer attribute!");

        var containerPartitionKey = dbContainerAttribute.PartitionKey;
        if (containerPartitionKey[0] != '/') containerPartitionKey = $"/{containerPartitionKey}";

        return containerPartitionKey;
    }

    public static string GetPartitionKeyValue<TDb>(this TDb tdb) where TDb : BaseDbEntry
    {
        var partitionKeyPath = typeof(TDb).GetPartitionKeyDefinition().Split("/")
            .Where(s => !string.IsNullOrWhiteSpace(s)).ToArray();
        var parameter = Expression.Parameter(typeof(TDb));
        Expression property = null!;
        foreach (var path in partitionKeyPath)
            property = property != null
                ? Expression.PropertyOrField(property, path)
                : Expression.PropertyOrField(parameter, path);

        var lambda = Expression.Lambda<Func<TDb, string>>(property, parameter);
        var compiledLambda = lambda.Compile();

        string partitionKeyValue = null!;
        try
        {
            partitionKeyValue = compiledLambda(tdb);
        }
        catch (InvalidCastException)
        {
            throw new InvalidCastException(
                $"The Partition Key set in the DbContainerAttribute of {typeof(TDb).FullName} is not a string!");
        }

        return partitionKeyValue;
    }

    private static DbContainerAttribute GetDbContainerAttribute(this Type type)
    {
        var dbContainerAttribute = type.GetCustomAttribute<DbContainerAttribute>();
        if (dbContainerAttribute == null)
            throw new InvalidOperationException(
                $"{type.FullName} is missing the DbContainer attribute!");

        return dbContainerAttribute;
    }
}