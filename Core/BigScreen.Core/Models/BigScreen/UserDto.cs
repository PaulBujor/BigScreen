using BigScreen.SDK.WebAPI.Core;

namespace BigScreen.Core.Models.BigScreen;

public class UserDto : BaseDto
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? DisplayName { get; set; }
    public bool? IsDeleted { get; set; }
    public ICollection<CachedTopListDto>? SavedTopLists { get; set; }
    public ICollection<CachedUserDto>? Following { get; set; }
}