using BigScreen.SDK.DataAccess.Core;

namespace BigScreen.SDK.DataAccess.Abstractions;

/// <summary>
///     Cosmos Database Builder
/// </summary>
public interface ICosmosDbBuilder
{
    /// <summary>
    ///     Adds a <see cref="IDbSet{TDb}" /> to the Cosmos Database instance.
    /// </summary>
    /// <typeparam name="TDb"></typeparam>
    /// <returns>The instance of the <see cref="ICosmosDbBuilder" /> on which this DbSet was added</returns>
    ICosmosDbBuilder AddDbSet<TDb>() where TDb : BaseDbEntry;
}