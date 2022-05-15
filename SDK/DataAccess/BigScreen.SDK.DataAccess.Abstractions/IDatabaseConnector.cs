using BigScreen.SDK.DataAccess.Core;
using Microsoft.Azure.Cosmos;

namespace BigScreen.SDK.DataAccess.Abstractions;

/// <summary>
///     Database Connector
/// </summary>
public interface IDatabaseConnector
{
    /// <summary>
    ///     Returns the <see cref="Container" /> for <typeparamref name="TDb" />
    /// </summary>
    /// <typeparam name="TDb">inheritor of <see cref="BaseDbEntry" /></typeparam>
    Container GetContainer<TDb>() where TDb : BaseDbEntry;
}