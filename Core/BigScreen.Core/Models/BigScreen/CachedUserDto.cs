using System.Runtime.Serialization;
using BigScreen.SDK.WebAPI.Core;

namespace BigScreen.Core.Models.BigScreen;

[DataContract]
public class CachedUserDto : BaseObject
{
    [DataMember(Name = "username")] public string? Username { get; set; }
}