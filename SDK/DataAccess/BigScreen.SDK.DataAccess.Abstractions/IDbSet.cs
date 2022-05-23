using System.Collections.Generic;
using System.Threading.Tasks;
using BigScreen.SDK.DataAccess.Core;

namespace BigScreen.SDK.DataAccess.Abstractions;

/// <summary>
///     Database Set for <typeparamref name="TDb" />
/// </summary>
/// <typeparam name="TDb">inheritor of <see cref="BaseDbEntry" /></typeparam>
public interface IDbSet<TDb> : IEnumerable<TDb> where TDb : BaseDbEntry
{
    /// <summary>
    ///     Returns a single item with the specified key
    /// </summary>
    Task<TDb> GetAsync(string key);

    /// <summary>
    ///     Create an item
    /// </summary>
    Task<TDb> CreateAsync(TDb tdb);

    /// <summary>
    ///     Update and item
    /// </summary>
    Task<TDb> UpdateAsync(TDb tdb);

    /// <summary>
    ///     Delete an item by its Object
    /// </summary>
    Task DeleteAsync(string key);
}