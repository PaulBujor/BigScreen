using BigScreen.Backend.Models;
using BigScreen.SDK.WebAPI;
using BigScreen.SDK.WebAPI.Abstractions;

namespace BigScreen.Backend.Controllers;

public class TestController : BaseODataController<TestDto>
{
    public TestController(IDataAccess<TestDto> dataAccess) : base(dataAccess)
    {
    }
}