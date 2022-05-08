using System.Runtime.Serialization;

namespace BigScreen.SDK.WebAPI.Core;

[DataContract]
public abstract class BaseObject
{
    [DataMember(Name = "id")] public string? Id { get; set; }
}