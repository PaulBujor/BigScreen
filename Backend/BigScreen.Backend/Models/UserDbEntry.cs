using BigScreen.SDK.DataAccess.Core;
using BigScreen.SDK.DataAccess.Core.Attributes;

namespace BigScreen.Backend.Models;

[DbContainer(PartitionKey = "id")]
public class UserDbEntry : BaseDbEntry
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? DisplayName { get; set; }
    public bool? IsDeleted { get; set; }
    public ICollection<CachedTopListDbo>? SavedTopLists { get; set; }
    public ICollection<CachedUserDbo>? Following { get; set; }
}