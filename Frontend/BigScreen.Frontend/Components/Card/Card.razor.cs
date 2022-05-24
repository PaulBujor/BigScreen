using BigScreen.Frontend.Components.Card.ViewModel;
using BigScreen.Frontend.Core.Enums;
using Microsoft.AspNetCore.Components;

namespace BigScreen.Frontend.Components.Card;

public partial class Card : ComponentBase
{
    [Inject]
    public ICardViewModel ViewModel { get; set; } = null!;
    
    [Parameter]
    public int? Id
    {
        get => ViewModel.Id;
        set => ViewModel.Id = value;
    }

    [Parameter]
    public string? Image { get; set; }
    
    [Parameter]
    public string? Header { get; set; }
    
    [Parameter]
    public string? Caption { get; set; }
    
    [Parameter]
    public RoutableTo? RoutableTo
    {
        get => ViewModel.RoutableTo;
        set => ViewModel.RoutableTo = value;
    }

    protected override void OnParametersSet()
    {
        var idMissing = Id is null;
        var imageMissing = string.IsNullOrEmpty(Image);
        var routableToMissing = RoutableTo is null;
        var mandatoryParametersMissing = idMissing || imageMissing || routableToMissing;
        
        if (mandatoryParametersMissing)
        {
            throw new ArgumentException("Id, Image and RoutableTo are mandatory parameters for Card component");
        }
        
        base.OnParametersSet();
    }
}