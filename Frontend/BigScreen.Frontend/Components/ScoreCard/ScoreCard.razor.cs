using BigScreen.Frontend.Components.ScoreCard.ViewModel;
using Microsoft.AspNetCore.Components;

namespace BigScreen.Frontend.Components.ScoreCard;

public partial class ScoreCard : ComponentBase
{
    [Inject]
    public IScoreCardViewModel ViewModel { get; set; } = null!;

    [Parameter]
    public double? Score
    {
        get => ViewModel.Score;
        set => ViewModel.Score = value ?? 0;
    }

    [Parameter]
    public string? Text { get; set; }

    [Parameter]
    public bool AllowScoring { get; set; }

    [Parameter]
    public EventCallback<int> ScoreChanged
    {
        get => ViewModel.ScoreChanged;
        set => ViewModel.ScoreChanged = value;
    }

    protected override void OnParametersSet()
    {
        var textMissing = string.IsNullOrEmpty(Text);
        var mandatoryParamsMissing = textMissing;

        if (mandatoryParamsMissing)
        {
            throw new ArgumentException("Mandatory parameters missing for ScoreCard");
        }

        base.OnParametersSet();
    }
}