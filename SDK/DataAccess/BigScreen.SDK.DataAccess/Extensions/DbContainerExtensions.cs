using System.Linq.Expressions;
using System.Reflection;
using BigScreen.SDK.DataAccess.Core;
using BigScreen.SDK.DataAccess.Core.Attributes;

namespace BigScreen.SDK.DataAccess.Extensions;

internal static class DbContainerExtensions
{
    /// <summary>
    ///     Will retrieve the Container ID from a <see cref="DbContainerAttribute" /> placed on the <typeparamref name="TDb" />
    ///     , or the name of the <typeparamref name="TDb" />
    /// </summary>
    /// <param name="type"></param>
    /// <returns></returns>
    public static string GetContainerId(this Type type)
    {
        var dbContainerAttribute = type.GetDbContainerAttribute();

        var containerId = string.IsNullOrWhiteSpace(dbContainerAttribute?.ContainerName)
            ? type.Name
            : dbContainerAttribute.ContainerName;

        return containerId;
    }

    /// <summary>
    ///     Will retrieve the Partition Key path from a <see cref="DbContainerAttribute" /> placed on the
    ///     <typeparamref name="TDb" />. It will pre-pend it with '/' if missing.
    /// </summary>
    /// <param name="type"></param>
    /// <returns></returns>
    /// <exception cref="InvalidOperationException"></exception>
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

    /// <summary>
    ///     Will return the value that is used as partition key in <typeparamref name="TDb" />. It is case insensitive to the
    ///     Partition Key defined in <see cref="DbContainerAttribute" />
    /// </summary>
    /// <param name="tdb"></param>
    /// <typeparam name="TDb"></typeparam>
    /// <returns></returns>
    /// <exception cref="InvalidCastException"></exception>
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

        try
        {
            var lambda = Expression.Lambda<Func<TDb, string>>(property, parameter);
            var compiledLambda = lambda.Compile();

            string partitionKeyValue = null!;
            partitionKeyValue = compiledLambda(tdb);
            return partitionKeyValue;
        }
        catch (ArgumentException)
        {
            throw new InvalidCastException(
                $"The Partition Key set in the DbContainerAttribute of {typeof(TDb).FullName} is not a string!");
        }
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