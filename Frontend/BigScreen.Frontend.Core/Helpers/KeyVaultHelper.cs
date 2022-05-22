using Azure.Identity;
using Azure.Security.KeyVault.Secrets;

namespace BigScreen.Frontend.Core.Helpers;

public class KeyVaultHelper
{
    private const string TmbdApiKeySecretName = "tmdbApiKey";
    private static readonly Uri KeyVaultName = new Uri("https://bigscreen-vault.vault.azure.net/");
    private static readonly SecretClient SecretClient = new SecretClient(KeyVaultName, new DefaultAzureCredential());

    public static async Task<string> GetTmdbApiKey()
    {
        var secret = await SecretClient.GetSecretAsync(TmbdApiKeySecretName);
        return secret.Value.Value;
    }
}