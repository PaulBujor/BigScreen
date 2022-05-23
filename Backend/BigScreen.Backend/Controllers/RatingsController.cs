using BigScreen.Core.Models.BigScreen;
using BigScreen.SDK.WebAPI;
using BigScreen.SDK.WebAPI.Abstractions;

namespace BigScreen.Backend.Controllers;

public class RatingsController : BaseODataController<RatingDto>
{
    public RatingsController(IDataAccess<RatingDto> dataAccess) : base(dataAccess)
    {
    }
}