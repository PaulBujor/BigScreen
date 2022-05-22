using BigScreen.SDK.WebAPI.Core;

namespace BigScreen.Backend.Core.Models;

public class TestDto : BaseDto
{
    public string? PartitionKey { get; set; }
    public string? Name { get; set; }
}