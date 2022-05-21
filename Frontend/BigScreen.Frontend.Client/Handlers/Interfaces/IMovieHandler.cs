using BigScreen.Core.Models.TMDb;

namespace BigScreen.Frontend.Client.Handlers.Interfaces;

public interface IMovieHandler
{
    Task<MovieDto?> GetMovieById(string id);
}