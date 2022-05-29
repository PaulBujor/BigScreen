using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace BigScreen.Frontend.Components.ScoreCard.ViewModel;

public interface IScoreCardViewModel
{
    double Score { get; set; }
    bool DialogVisible { get; set; }
    EventCallback<int> ScoreChanged { get; set; }
    double GetConvertedScore();
    Color GetColor();
    string GetScoreText();
    Task RatingChanged(int score);
}