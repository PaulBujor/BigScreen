using BigScreen.Core.Models.TMDb;

namespace BigScreen.Frontend.Client.Handlers.Interfaces;

public interface IPersonHandler
{
    Task<PersonDto?> GetPerson(int id);
}