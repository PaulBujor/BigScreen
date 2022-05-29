using BigScreen.Core.Models.TMDb.Base;
using BigScreen.Frontend.Core.Attributes;

namespace BigScreen.Core.Models.TMDb;

[TmdbDto("search")]
public class SearchPageResultsDto : BaseSearchResultsDto<SearchResultDto>
{
}