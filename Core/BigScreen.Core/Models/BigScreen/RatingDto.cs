using System.Runtime.Serialization;
using BigScreen.SDK.WebAPI.Core;
using BigScreen.SDK.WebAPI.Core.Attributes;

namespace BigScreen.Core.Models.BigScreen;

[DataContract]
[EdmCollection("Ratings")]
public class RatingDto : BaseDto
{
    [DataMember(Name = "forMovie")]
    public string? ForMovie { get; set; }

    [DataMember(Name = "byUser")]
    public string? ByUser { get; set; }

    [DataMember(Name = "score")]
    public int? Score { get; set; }
}