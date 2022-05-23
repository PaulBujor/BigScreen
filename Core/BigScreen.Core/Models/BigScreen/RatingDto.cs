using BigScreen.SDK.WebAPI.Core;

namespace BigScreen.Core.Models.BigScreen;

public class RatingDto : BaseDto
{
    public string? ForMovie { get; set; }
    public string? ByUser { get; set; }
    public int? Score { get; set; }
}