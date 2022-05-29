namespace BigScreen.Frontend.Client.Constants;

public static class BigScreenClientConstants
{
    public const string ClientName = "BigScreenClient";
    private static string _baseAddress = "https://bigscreen-api.azurewebsites.net/api";
    private static readonly string _localAdress = "https://localhost:7171/api";

    public static string GetBaseAddress()
    {
#if DEBUG
        return _localAdress;
#else
        return BaseAddress;
#endif
    }
}