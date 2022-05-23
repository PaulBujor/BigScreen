using Azure.Identity;
using Azure.Security.KeyVault.Secrets;

namespace BigScreen.Frontend.Core.Helpers;

public class KeyVaultHelper
{
    private const string TmdbApiKeySecretName = "tmdbApiKey";
    private readonly SecretClient _secretClient;
    private readonly Uri KeyVaultName;
    public const string TmdbApiKey = "460ff555602c9fc58a41487667e40b74";

    public KeyVaultHelper()
    {
        KeyVaultName = new Uri("https://bigscreen-vault.vault.azure.net/");
        var defaultAzureCredential = new ManagedIdentityCredential();
        _secretClient = new SecretClient(KeyVaultName, defaultAzureCredential);
    }

    // KeyVault doesn't work because of CORS
    // Web and Azure KeyVault limitation
    public async Task<string> GetTmdbApiKey()
    {
        var secret = await _secretClient.GetSecretAsync(TmdbApiKeySecretName);
        return secret.Value.Value;
    }
}