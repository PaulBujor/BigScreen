using System.Runtime.Serialization;
using BigScreen.SDK.WebAPI.Core;

namespace BigScreen.Core.Models.BigScreen;

[DataContract]
public class CachedTopListDto : BaseObject
{
    [DataMember(Name = "title")] public string? Title { get; set; }
}