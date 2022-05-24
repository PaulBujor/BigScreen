using BigScreen.Frontend.Core.Enums;

namespace BigScreen.Frontend.Components.Card.ViewModel;

public interface ICardViewModel
{
    public int? Id { get; set; }
    RoutableTo? RoutableTo { get; set; }
    string GetUrl();
}