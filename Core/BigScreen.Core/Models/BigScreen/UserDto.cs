using System.Runtime.Serialization;
using BigScreen.SDK.WebAPI.Core;

namespace BigScreen.Core.Models.BigScreen;

[DataContract]
public class UserDto : BaseDto
{
    [DataMember(Name = "username")] public string? Username { get; set; }

    [DataMember(Name = "isDeleted")] public bool? IsDeleted { get; set; }

    [DataMember(Name = "savedTopLists")] public ICollection<CachedTopListDto>? SavedTopLists { get; set; }

    [DataMember(Name = "following")] public ICollection<CachedUserDto>? Following { get; set; }

    public CachedUserDto GetCachedVersion()
    {
        return new CachedUserDto
        {
            Id = Id,
            Username = Username
        };
    }
}