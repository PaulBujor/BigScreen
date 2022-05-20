using BigScreen.Frontend.Core;
using BigScreen.SDK.Client.Abstractions;

namespace BigScreen.Frontend.Client;

public class TmdbClient<TDto> : IClient<TDto> where TDto : TmdbDto
{
}