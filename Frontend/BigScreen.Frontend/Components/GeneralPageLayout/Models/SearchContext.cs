namespace BigScreen.Frontend.Components.GeneralPageLayout.Models;

public class SearchContext<TFilter>
{
    public SearchContext(int page, TFilter filter)
    {
        Page = page;
        Filter = filter;
    }

    public SearchContext(int page, TFilter filter, string query)
    {
        Page = page;
        Filter = filter;
        Query = query;
    }

    public int Page { get; }
    public TFilter Filter { get; }
    public string? Query { get; }
}