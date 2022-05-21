namespace BigScreen.Frontend.Core.Attributes;
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Interface)]
public class TmdbDtoAttribute : Attribute
{
    public string? RequestUri { get; }

    public TmdbDtoAttribute(string? requestUri)
    {
        RequestUri = requestUri;
    }
}