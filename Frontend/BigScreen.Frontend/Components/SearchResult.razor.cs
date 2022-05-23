using BigScreen.Core.Models.TMDb;
using Microsoft.AspNetCore.Components;

namespace BigScreen.Frontend.Components;

public partial class SearchResult : ComponentBase
{
    [Parameter] public SearchResultDto? Result { get; set; }

}