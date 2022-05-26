namespace BigScreen.Frontend.Components.MediaDetailsPageLayout.Models;

public class MediaModel
{
    public string? ImageUrl { get; set; }

    public string Title { get; set; } = null!;

    public DateOnly? ReleaseDate { get; set; }

    public string[]? Genres { get; set; }

    public TimeSpan Duration { get; set; }

    public string? Tagline { get; set; }

    public string? Overview { get; set; }

    public bool AddedToToplist { get; set; }

    public double? TmdbScore { get; set; }

    public double? BigScreenScore { get; set; }

    public double? UserScore { get; set; }

    public MediaModel(string? imageUrl, string title, DateOnly? releaseDate, string[]? genres, TimeSpan duration,
        string? tagline, string? overview, bool addedToToplist, double? tmdbScore, double? bigScreenScore,
        double? userScore)
    {
        ImageUrl = imageUrl;
        Title = title;
        ReleaseDate = releaseDate;
        Genres = genres;
        Duration = duration;
        Tagline = tagline;
        Overview = overview;
        AddedToToplist = addedToToplist;
        TmdbScore = tmdbScore;
        BigScreenScore = bigScreenScore;
        UserScore = userScore;
    }
}