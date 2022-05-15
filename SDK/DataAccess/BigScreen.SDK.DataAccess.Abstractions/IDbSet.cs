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
    ///     Get an item by its ID
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<TDb> GetAsync(string id, string partitionKey);

    /// <summary>
    ///     Create an item
    /// </summary>
    /// <param name="tdb"></param>
    /// <returns></returns>
    Task<TDb> CreateAsync(TDb tdb);

    /// <summary>
    ///     Update and item
    /// </summary>
    /// <param name="tdb"></param>
    /// <returns></returns>
    Task<TDb> UpdateAsync(TDb tdb);

    /// <summary>
    ///     Delete an item by its ID
    /// </summary>
    /// <param name="id"></param>
    /// <param name="partitionKey"></param>
    /// <returns></returns>
    Task DeleteByIdAsync(string id, string partitionKey);

    /// <summary>
    ///     Delete an item by its Object
    /// </summary>
    /// <param name="tdb"></param>
    /// <returns></returns>
    Task DeleteAsync(TDb tdb);
}