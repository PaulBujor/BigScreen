using BigScreen.SDK.Client.Abstractions;
using BigScreen.SDK.WebAPI.Core;

namespace BigScreen.SDK.Client;

public class BaseODataClient<TDto> : IClient<TDto> where TDto : BaseDto
{
}