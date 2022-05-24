using BigScreen.Frontend.Core.Enums;

namespace BigScreen.Frontend.Client.Handlers.Interfaces;

public interface IGeneralSearchPageResults<TGeneralSearchDto> where TGeneralSearchDto : class
{
    Task<TGeneralSearchDto?> GetGeneralSearchBySortType(SortFilter filter);
}