using BigScreen.Core.Models.TMDb;
using BigScreen.Frontend.Constants;
using BigScreen.Frontend.Core.Enums;

namespace BigScreen.Frontend.Components.SearchResult.ViewModel;

public class SearchResultViewModel : ISearchResultViewModel
{
    public SearchResultDto Result { get; set; } = null!;
    public SearchFilter FilterContext { get; set; }

    public string GetResultHref() => FilterContext switch
    {
        SearchFilter.All => $"/{ConvertTypeForDetailsRouting(Result.Type)}/{Result.Id}",
        SearchFilter.Movies => $"/{RouteConstants.MovieDetails}/{Result.Id}",
        SearchFilter.People => $"/{RouteConstants.PersonDetails}/{Result.Id}",
        SearchFilter.TvShows => $"/{RouteConstants.TvShowDetails}/{Result.Id}",
        _ => throw new ArgumentOutOfRangeException()
    };

    public string GetTypeHref() => FilterContext switch
    {
        SearchFilter.All => $"/{ConvertTypeForGeneralRouting(Result.Type)}",
        SearchFilter.Movies => $"/{RouteConstants.MoviesGeneral}",
        SearchFilter.People => $"/{RouteConstants.PeopleGeneral}",
        SearchFilter.TvShows => $"/{RouteConstants.TvShowsGeneral}",
        _ => throw new ArgumentOutOfRangeException()
    };

    public string GetTypeDisplay() => FilterContext switch
    {
        SearchFilter.All => $"{ConvertTypeForDisplay(Result.Type)}",
        SearchFilter.Movies => "Movie",
        SearchFilter.People => "Person",
        SearchFilter.TvShows => "TV Show",
        _ => throw new ArgumentOutOfRangeException(nameof(FilterContext))
    };


    private string ConvertTypeForDisplay(string? type) => type?.ToLower() switch
    {
        "movie" => "Movie",
        "tv" => "TV Show",
        "person" => "Person",
        _ => throw new ArgumentOutOfRangeException(nameof(type), $"Not expected type value: {type}")
    };

    private string ConvertTypeForDetailsRouting(string? type) => type?.ToLower() switch
    {
        "movie" => $"{RouteConstants.MovieDetails}",
        "tv" => $"{RouteConstants.TvShowDetails}",
        "person" => $"{RouteConstants.PersonDetails}",
        _ => throw new ArgumentOutOfRangeException(nameof(type), $"Not expected type value: {type}")
    };

    private string ConvertTypeForGeneralRouting(string? type) => type?.ToLower() switch
    {
        "movie" => $"{RouteConstants.MoviesGeneral}",
        "tv" => $"{RouteConstants.TvShowsGeneral}",
        "person" => $"{RouteConstants.PeopleGeneral}",
        _ => throw new ArgumentOutOfRangeException(nameof(type), $"Not expected type value: {type}")
    };
}