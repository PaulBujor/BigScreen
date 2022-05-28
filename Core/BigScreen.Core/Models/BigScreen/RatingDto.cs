using System.Runtime.Serialization;
using BigScreen.SDK.WebAPI.Core;

namespace BigScreen.Core.Models.BigScreen;

[DataContract]
public class RatingDto : BaseDto
{
    [DataMember(Name = "forMovie")] public string? ForMovie { get; set; }

    [DataMember(Name = "byUser")] public string? ByUser { get; set; }

    [DataMember(Name = "score")] public int? Score { get; set; }
}