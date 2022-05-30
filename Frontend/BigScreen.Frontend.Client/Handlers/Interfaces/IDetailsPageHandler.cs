using BigScreen.Frontend.Core;

namespace BigScreen.Frontend.Client.Handlers.Interfaces;

public interface IDetailsPageHandler<TDetailsDto> where TDetailsDto : TmdbDto
{
    Task<TDetailsDto?> GetMediaDetailsAsync(int id);
}