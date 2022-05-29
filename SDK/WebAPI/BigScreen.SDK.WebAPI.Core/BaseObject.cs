using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace BigScreen.SDK.WebAPI.Core;

[DataContract]
public abstract class BaseObject
{
    [DataMember(Name = "id")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public string? Id { get; set; }
}