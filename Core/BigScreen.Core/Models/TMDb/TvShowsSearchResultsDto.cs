using BigScreen.Frontend.Core.Attributes;

namespace BigScreen.Core.Models.TMDb;

[TmdbDto("tv")]
public class TvShowsSearchResultsDto : BaseSearchResultsDto<TvShowSearchResultDto>
{
}