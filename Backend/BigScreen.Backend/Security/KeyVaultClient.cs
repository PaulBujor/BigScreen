// ReSharper disable once RedundantUsingDirective

using Azure.Identity;
using Azure.Security.KeyVault.Secrets;

namespace BigScreen.Backend.Security;

public class KeyVaultClient
{
    private readonly SecretClient _secretClient = null!;

    public KeyVaultClient()
    {
#if !DEBUG
        _secretClient = new SecretClient(new Uri("https://bigscreen-vault.vault.azure.net/"),
            new DefaultAzureCredential());
#endif
    }

    public string GetAccessKey()
    {
#if DEBUG
        return "C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==";
#endif
        return _secretClient.GetSecret("cosmosAccessKey").Value.Value;
    }

    public string GetEndPoint()
    {
#if DEBUG
        return "https://localhost:8081";
#endif

        return _secretClient.GetSecret("cosmosURL").Value.Value;
    }
}