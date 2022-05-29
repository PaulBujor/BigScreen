using System.Runtime.Serialization;
using BigScreen.SDK.WebAPI.Core;
using BigScreen.SDK.WebAPI.Core.Attributes;

namespace BigScreen.Core.Models.BigScreen;

[DataContract]
[EdmCollection("Users")]
public class UserDto : BaseDto
{
    [DataMember(Name = "firstName")] public string? FirstName { get; set; }

    [DataMember(Name = "lastName")] public string? LastName { get; set; }

    [DataMember(Name = "displayName")] public string? DisplayName { get; set; }

    [DataMember(Name = "isDeleted")] public bool? IsDeleted { get; set; }

    [DataMember(Name = "savedTopLists")] public ICollection<CachedTopListDto>? SavedTopLists { get; set; }

    [DataMember(Name = "following")] public ICollection<CachedUserDto>? Following { get; set; }
}