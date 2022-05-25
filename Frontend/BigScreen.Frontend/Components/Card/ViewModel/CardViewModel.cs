using BigScreen.Frontend.Core.Enums;
using BigScreen.Frontend.Core.Helpers;

namespace BigScreen.Frontend.Components.Card.ViewModel;

public class CardViewModel : ICardViewModel
{
    public int? Id { get; set; } = null!;
    public RoutableTo? RoutableTo { get; set; } = null!;
    public string GetUrl() => RoutableToHelper.GetUrl(RoutableTo!.Value, Id!.Value);
}