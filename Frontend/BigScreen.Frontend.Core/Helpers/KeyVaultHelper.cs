using Azure.Identity;
using Azure.Security.KeyVault.Secrets;

namespace BigScreen.Frontend.Core.Helpers;

public class KeyVaultHelper
{
    private const string TmbdApiKeySecretName = "tmdbApiKey";


    public static string GetTmdbApiKey()
    {
    var KeyVaultName = new Uri("https://bigscreen-vault.vault.azure.net/");
    var defaultAzureCredential = new DefaultAzureCredential();
    var SecretClient = new SecretClient(KeyVaultName, defaultAzureCredential);
    var secret =  SecretClient.GetSecret(TmbdApiKeySecretName);
        return secret.Value.Value;
    }
}