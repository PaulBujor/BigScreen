namespace BigScreen.SDK.DataAccess.Core.Attributes;

/// <summary>
///     Attribute that specifies how the container should be named and what partition key should be used for the container
/// </summary>
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Interface)]
public class DbContainerAttribute : Attribute
{
    /// <summary>
    ///     Name the container for this DbSet should have. Name of the class will be used if this is missing.
    /// </summary>
    public string? ContainerName { get; set; }

    /// <summary>
    ///     The partition key of this container. ICosmosDbBuilder will prepend with '/' if it is missing.
    ///     <remarks>
    ///         Be aware that the given Partition Key must match the JSON-serialized names for Cosmos DB to understand
    ///         them correctly. If a property is serialized to 'camelCase', then the partition key should also be 'camelCase'.
    ///     </remarks>
    /// </summary>
    public string PartitionKey { get; set; } = null!;
}