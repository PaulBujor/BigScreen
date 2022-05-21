namespace BigScreen.Frontend.Core.Attributes;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Interface)]
public class TmdbDtoAttribute : Attribute
{
    public TmdbDtoAttribute(string requestUri)
    {
        RequestUri = requestUri;
    }

    public string RequestUri { get; }
}