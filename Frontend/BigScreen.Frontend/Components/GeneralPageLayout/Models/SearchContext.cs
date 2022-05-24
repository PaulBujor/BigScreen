using BigScreen.Frontend.Core.Enums;

namespace BigScreen.Frontend.Components.GeneralPageLayout.Models;

public class SearchContext
{
    public int Page { get; }
    public SortFilter SortFilter { get; }
    public string? Query { get; }    
    
    public SearchContext(int page, SortFilter sortFilter)
    {
        Page = page;
        SortFilter = sortFilter;
    }
    
    public SearchContext(int page, SortFilter sortFilter, string query)
    {
        Page = page;
        SortFilter = sortFilter;
        Query = query;
    }
}