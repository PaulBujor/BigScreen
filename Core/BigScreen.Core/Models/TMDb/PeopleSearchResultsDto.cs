using BigScreen.Core.Models.TMDb.Base;
using BigScreen.Frontend.Core.Attributes;

namespace BigScreen.Core.Models.TMDb;

[TmdbDto("person")]
public class PeopleSearchResultsDto : BaseSearchResultsDto<PersonSearchResultDto>
{
}