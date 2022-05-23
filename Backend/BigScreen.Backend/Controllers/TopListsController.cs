using BigScreen.Core.Models.BigScreen;
using BigScreen.SDK.WebAPI;
using BigScreen.SDK.WebAPI.Abstractions;

namespace BigScreen.Backend.Controllers;

public class TopListsController : BaseODataController<TopListDto>
{
    public TopListsController(IDataAccess<TopListDto> dataAccess) : base(dataAccess)
    {
    }
}