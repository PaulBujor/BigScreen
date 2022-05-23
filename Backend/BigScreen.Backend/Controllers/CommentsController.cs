using BigScreen.Core.Models.BigScreen;
using BigScreen.SDK.WebAPI;
using BigScreen.SDK.WebAPI.Abstractions;

namespace BigScreen.Backend.Controllers;

public class CommentsController : BaseODataController<CommentDto>
{
    public CommentsController(IDataAccess<CommentDto> dataAccess) : base(dataAccess)
    {
    }
}