using System.Runtime.Serialization;
using BigScreen.SDK.WebAPI.Core;
using BigScreen.SDK.WebAPI.Core.Attributes;

namespace BigScreen.Core.Models.BigScreen;

[DataContract]
[EdmCollection("Ratings")]
public class RatingDto : BaseDto
{
    [DataMember] public string? ForMedia { get; set; }

    [DataMember] public string? ByUser { get; set; }

    [DataMember] public double? Score { get; set; }
}