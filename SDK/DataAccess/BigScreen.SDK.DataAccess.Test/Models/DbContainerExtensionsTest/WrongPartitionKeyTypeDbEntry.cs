using BigScreen.SDK.DataAccess.Core;
using BigScreen.SDK.DataAccess.Core.Attributes;

namespace BigScreen.SDK.DataAccess.Test.Models.DbContainerExtensionsTest;

[DbContainer(PartitionKey = "nonString")]
public class WrongPartitionKeyTypeDbEntry : BaseDbEntry
{
    public int? NonString { get; set; }
}