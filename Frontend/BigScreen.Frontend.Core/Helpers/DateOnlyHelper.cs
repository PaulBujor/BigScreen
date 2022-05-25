namespace BigScreen.Frontend.Core.Helpers;

public class DateOnlyHelper
{
    public static string? GetTextForCardCaption(DateOnly? date) => date?.ToString("MMMM dd, yyyy");
}