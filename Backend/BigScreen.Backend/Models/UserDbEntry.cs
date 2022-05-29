using BigScreen.SDK.DataAccess.Core;
using BigScreen.SDK.DataAccess.Core.Attributes;

namespace BigScreen.Backend.Models;

[DbContainer(PartitionKey = nameof(Id))]
public class UserDbEntry : BaseDbEntry
{
    public string? Username { get; set; }
    public bool? IsDeleted { get; set; }
    public ICollection<CachedTopListDbo>? SavedTopLists { get; set; }
    public ICollection<CachedUserDbo>? Following { get; set; }
}