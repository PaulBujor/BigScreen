using BigScreen.SDK.DataAccess.Core;

namespace BigScreen.SDK.DataAccess.Abstractions;

/// <summary>
///     Database Set for <typeparamref name="TDb" />
/// </summary>
/// <typeparam name="TDb">inheritor of <see cref="BaseDbEntry" /></typeparam>
public interface IDbSet<TDb> where TDb : BaseDbEntry
{
}