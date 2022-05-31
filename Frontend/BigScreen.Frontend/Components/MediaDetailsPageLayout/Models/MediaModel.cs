using BigScreen.Core.Models.BigScreen;
using BigScreen.Core.Models.TMDb.Base;

namespace BigScreen.Frontend.Components.MediaDetailsPageLayout.Models;

public class MediaModel
{
    public MediaModel(string? imageUrl, string title, DateOnly? releaseDate, string[]? genres, TimeSpan duration,
        string? tagline, string? overview, double? tmdbScore, string? status, double? budget,
        double? revenue)
    {
        ImageUrl = imageUrl;
        Title = title;
        ReleaseDate = releaseDate;
        Genres = genres;
        Duration = duration;
        Tagline = tagline;
        Overview = overview;
        TmdbScore = tmdbScore;
        Status = status;
        Budget = budget;
        Revenue = revenue;
    }

    public MediaModel(string? imageUrl, string title, DateOnly? releaseDate, string[]? genres, TimeSpan duration,
        string? tagline, string? overview, double? tmdbScore, double? bigScreenScore,
        RatingDto? userScore, string? status, double? budget, double? revenue)
    {
        ImageUrl = imageUrl;
        Title = title;
        ReleaseDate = releaseDate;
        Genres = genres;
        Duration = duration;
        Tagline = tagline;
        Overview = overview;
        TmdbScore = tmdbScore;
        BigScreenScore = bigScreenScore;
        UserScore = userScore;
        Status = status;
        Budget = budget;
        Revenue = revenue;
    }

    public MediaModel()
    {
    }

    public string? ImageUrl { get; set; }

    public string Title { get; set; } = null!;

    public DateOnly? ReleaseDate { get; set; }

    public string[]? Genres { get; set; }

    public TimeSpan Duration { get; set; }

    public string? Tagline { get; set; }

    public string? Overview { get; set; }

    public double? TmdbScore { get; set; }

    public double? BigScreenScore { get; set; }

    public RatingDto? UserScore { get; set; }
    public string? Status { get; set; }

    public double? Budget { get; set; }
    public double? Revenue { get; set; }

    public static MediaModel? FromMediaDto<TDto>(TDto? dto) where TDto : BaseMediaDetailsDto
    {
        if (dto is not null && dto.Name != null && dto.Genres != null)
        {
            return new MediaModel(dto.ImageUrl, dto.Name, dto.ReleaseDate, dto.Genres.Select(g => g?.Name).ToArray()!,
                dto.Duration,
                dto.Tagline, dto.Overview, dto.TmdbScore, dto.Status, dto.Budget, dto.Revenue);
        }

        return null;
    }
}