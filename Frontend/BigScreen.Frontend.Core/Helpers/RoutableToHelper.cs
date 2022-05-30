using BigScreen.Frontend.Core.Constants;
using BigScreen.Frontend.Core.Enums;

namespace BigScreen.Frontend.Core.Helpers;

public class RoutableToHelper
{
    
    public static RoutableTo GetRoutableToByType(string? type) => type switch
    {
        "movie" => RoutableTo.Movie,
        "tv" => RoutableTo.TvShow,
        "person" => RoutableTo.Person,
        _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
    };
    public static string GetUrl(RoutableTo type, int id) => type switch
    {
        RoutableTo.Movie => $"/{RouteConstants.MovieDetails}/{id}",
        RoutableTo.TvShow => $"/{RouteConstants.TvShowDetails}/{id}",
        RoutableTo.Person => $"/{RouteConstants.PersonDetails}/{id}",
        _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
    };
}