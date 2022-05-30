namespace BigScreen.Frontend.Client.Constants;

public static class BigScreenClientConstants
{
    public const string ClientName = "BigScreenClient";
    private const string BaseAddress = "https://bigscreen-api.azurewebsites.net/api";
    private const  string LocalAddress = "https://localhost:7171/api";

    public static string GetBaseAddress()
    {
#if DEBUG
        return LocalAddress;
#else
        return BaseAddress;
#endif
    }
}