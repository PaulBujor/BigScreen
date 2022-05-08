using System.Runtime.Serialization;

namespace BigScreen.SDK.WebAPI.Core;

[DataContract]
public class BaseDto : BaseObject
{
    [DataMember(Name = "_etag")] public string? ETag { get; set; }
}