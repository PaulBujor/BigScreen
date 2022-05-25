using BigScreen.Frontend.Core.Enums;

namespace BigScreen.Frontend.Client.Handlers.Interfaces;

public interface IGeneralSearchPageResultsHandler<TGeneralSearchDto> where TGeneralSearchDto : class
{
    Task<TGeneralSearchDto?> GetGeneralSearchBySortType(SortFilter filter, int page);
}