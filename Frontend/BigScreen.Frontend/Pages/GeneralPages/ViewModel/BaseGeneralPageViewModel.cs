using BigScreen.Frontend.Client.Handlers.Interfaces;
using BigScreen.Frontend.Components.GeneralPageLayout.Models;
using BigScreen.Frontend.Core.Enums;

namespace BigScreen.Frontend.Pages.GeneralPages.ViewModel;

public abstract class BaseGeneralPageViewModel<TSearchResultsDto> : IBaseGeneralPageViewModel<TSearchResultsDto> where TSearchResultsDto : class
{
    public virtual TSearchResultsDto? PageResults { get; set; }

    private readonly IGeneralSearchPageResults<TSearchResultsDto> _handler;
    
    protected BaseGeneralPageViewModel(IGeneralSearchPageResults<TSearchResultsDto> handler)
    {
        _handler = handler;
    }
    
    public virtual async Task CallSearch(SortFilter sortFilter, int page)
    {
        PageResults = await _handler.GetGeneralSearchBySortType(sortFilter, page);
    }

    public virtual async Task OnSearchContextChanged(SearchContext<SortFilter> searchContext)
    {
        await CallSearch(searchContext.Filter, searchContext.Page);
    }
}