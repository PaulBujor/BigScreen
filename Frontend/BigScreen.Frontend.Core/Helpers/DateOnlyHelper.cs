namespace BigScreen.Frontend.Core.Helpers;

public static class DateOnlyHelper
{
    public static string? GetTextForCardCaption(DateOnly? date) => date?.ToString("MMMM dd, yyyy");
    public static string? GetTextForCardCaption(this DateOnly date) => date.ToString("MMMM dd, yyyy");
}