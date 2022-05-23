using BigScreen.Core.Models.BigScreen;
using BigScreen.SDK.WebAPI;
using BigScreen.SDK.WebAPI.Abstractions;

namespace BigScreen.Backend.Controllers;

public class UsersController : BaseODataController<UserDto>
{
    public UsersController(IDataAccess<UserDto> dataAccess) : base(dataAccess)
    {
    }
}