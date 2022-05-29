using System.Globalization;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace BigScreen.Frontend.Components.ScoreCard.ViewModel;

public class ScoreCardViewModel : IScoreCardViewModel
{
    private const string NotRatedText = "-";

    public double Score { get; set; }
    public double GetConvertedScore() => Score == 0 ? 100 : Score * 10;

    public bool DialogVisible { get; set; }

    public async Task RatingChanged(int score)
    {
        Score = score; // doubts
        await ScoreChanged.InvokeAsync(score);
        DialogVisible = false;
    }

    public EventCallback<int> ScoreChanged { get; set; }

    public Color GetColor()
    {
        switch (Score)
        {
            case 0:
                return Color.Default;
            case <= 5:
                return Color.Error;
            case > 5 and < 7:
                return Color.Warning;
            case >= 7:
                return Color.Success;
            default:
                return Color.Default;
        }
    }

    public string GetScoreText() => Score > 0 ? Score.ToString(CultureInfo.CurrentCulture) : NotRatedText;
}