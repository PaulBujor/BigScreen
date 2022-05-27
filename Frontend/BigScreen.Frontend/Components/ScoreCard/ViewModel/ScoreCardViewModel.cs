using System.Globalization;
using MudBlazor;

namespace BigScreen.Frontend.Components.ScoreCard.ViewModel;

public class ScoreCardViewModel : IScoreCardViewModel
{
    private const string NotRatedText = "-";

    public double? Score { get; set; } = null!;
    public double GetConvertedScore() => Score!.Value == 0 ? 100 : Score!.Value * 10;

    public Color GetColor()
    {
        switch (Score!.Value)
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

    public string GetScoreText() => Score!.Value > 0 ? Score!.Value.ToString(CultureInfo.CurrentCulture) : NotRatedText;

}