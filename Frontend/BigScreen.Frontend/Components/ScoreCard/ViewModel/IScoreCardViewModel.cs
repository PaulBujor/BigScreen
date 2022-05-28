using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace BigScreen.Frontend.Components.ScoreCard.ViewModel;

public interface IScoreCardViewModel
{
    double Score { get; set; }
    double GetConvertedScore();
    Color GetColor();
    string GetScoreText();
    bool DialogVisible { get; set; }
    Task RatingChanged(int score);
    EventCallback<int> ScoreChanged { get; set; }
}