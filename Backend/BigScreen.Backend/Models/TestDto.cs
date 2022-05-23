using System.Runtime.Serialization;
using BigScreen.SDK.WebAPI.Core;

namespace BigScreen.Backend.Models;

[DataContract]
public class TestDto : BaseDto
{
    [DataMember] public string? PartitionKey { get; set; }

    [DataMember] public string? Name { get; set; }
}