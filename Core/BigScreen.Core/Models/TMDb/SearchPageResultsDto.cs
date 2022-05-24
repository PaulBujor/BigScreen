using BigScreen.Frontend.Core;
using BigScreen.Frontend.Core.Attributes;
using Newtonsoft.Json;

namespace BigScreen.Core.Models.TMDb;

[TmdbDto("search")]
public class SearchPageResultsDto : BaseSearchResultsDto<SearchResultDto>
{
}