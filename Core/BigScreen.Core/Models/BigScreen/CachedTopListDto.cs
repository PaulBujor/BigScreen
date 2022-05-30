using System.Runtime.Serialization;
using BigScreen.SDK.WebAPI.Core;

namespace BigScreen.Core.Models.BigScreen;

[DataContract]
public class CachedTopListDto : BaseObject
{
    [DataMember] public string? Title { get; set; }
}