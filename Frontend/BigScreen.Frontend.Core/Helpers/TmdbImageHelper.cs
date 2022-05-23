using BigScreen.Frontend.Core.Constants;
using BigScreen.Frontend.Core.Enums;

namespace BigScreen.Frontend.Core.Helpers;

public class TmdbImageHelper
{
    public static string? GetImageUrl(string? path, ImageSize size)
    {
        if (path == null)
        {
            return null;
        }

        return TmdbImageConstants.BaseImageUrl + GetImageWidth(size) + path;
    }

    private static string GetImageWidth(ImageSize size) => size switch
    {
        ImageSize.InSearch => "w92",
        ImageSize.InDetailsPage => "w185",
        _ => throw new ArgumentOutOfRangeException(nameof(size), $"Not expected image size with value: {size}")
        // Known size from api docs: 45, 92, 154, 185, 300, 342, 500, 780, original
    };
}