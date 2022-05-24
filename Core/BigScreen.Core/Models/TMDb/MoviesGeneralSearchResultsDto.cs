using BigScreen.Frontend.Core.Attributes;

namespace BigScreen.Core.Models.TMDb;

[TmdbDto("movie")]
public class MoviesGeneralSearchResultsDto : BaseSearchResultsDto<MovieSearchResultDto>
{
}