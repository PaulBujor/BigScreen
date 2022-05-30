using System.Runtime.Serialization;
using BigScreen.SDK.WebAPI.Core;
using BigScreen.SDK.WebAPI.Core.Attributes;
using Microsoft.OData.ModelBuilder;

namespace BigScreen.Core.Models.BigScreen;

[DataContract]
[EdmCollection("Users")]
public class UserDto : BaseDto
{
    [DataMember] public string? Username { get; set; }

    [DataMember] public bool? IsDeleted { get; set; }

    [AutoExpand] [DataMember] public ICollection<CachedTopListDto>? SavedTopLists { get; set; }

    [AutoExpand] [DataMember] public ICollection<CachedUserDto>? Following { get; set; }

    public CachedUserDto GetCachedVersion()
    {
        return new CachedUserDto
        {
            Id = Id,
            Username = Username
        };
    }
}