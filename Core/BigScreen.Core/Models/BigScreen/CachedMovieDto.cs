using System.Runtime.Serialization;
using BigScreen.Frontend.Core.Enums;
using BigScreen.SDK.WebAPI.Core;

namespace BigScreen.Core.Models.BigScreen;

[DataContract]
public class CachedMovieDto : BaseObject
{
    [DataMember(Name = "title")] public string? Name { get; set; }

    [DataMember(Name = "posterImageUrl")] public string? ImageUrl { get; set; }

    public RoutableTo GetRoutableTo()
    {
        if (Id.Contains("movie"))
            return RoutableTo.Movie;

        return Id.Contains("tv") ? RoutableTo.TvShow : default;
    }

    public int GetTmdbId()
    {
        return int.Parse(Id?.Split('-', 2)[1] ?? "0");
    }
}