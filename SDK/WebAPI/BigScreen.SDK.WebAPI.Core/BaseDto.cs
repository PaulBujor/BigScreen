using System.Runtime.Serialization;

namespace BigScreen.SDK.WebAPI.Core;

[DataContract]
public class BaseDto : BaseObject
{
    [DataMember] public string? ETag { get; set; }
}