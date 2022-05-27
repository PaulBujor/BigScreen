using MudBlazor;

namespace BigScreen.Frontend.Components.ScoreCard.ViewModel;

public interface IScoreCardViewModel
{
    double? Score { get; set; }
    double GetConvertedScore();
    Color GetColor();
    string GetScoreText();
}