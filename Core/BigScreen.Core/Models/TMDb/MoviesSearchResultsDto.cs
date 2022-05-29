using BigScreen.Core.Models.TMDb.Base;
using BigScreen.Frontend.Core.Attributes;

namespace BigScreen.Core.Models.TMDb;

[TmdbDto("movie")]
public class MoviesSearchResultsDto : BaseSearchResultsDto<MovieSearchResultDto>
{
}