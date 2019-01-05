using System;
using System.Threading.Tasks;
using Microsoft.Azure.KeyVault;
using Microsoft.Azure.Services.AppAuthentication;
using Xunit;

namespace KeyVaultTests
{
    public class UnitTest1
    {
        [Fact]
        public async Task Test1()
        {
            var azureServiceTokenProvider1 = new AzureServiceTokenProvider();
            var kv = new KeyVaultClient(
                new KeyVaultClient.AuthenticationCallback(
                    azureServiceTokenProvider1.KeyVaultTokenCallback));

            var secret = await kv.GetSecretAsync("https://anthony.vault.azure.net/secrets/mysecret/0f0547e2c14d47f69593782a5b00acbe");

            Assert.Equal("My super secret value", secret.Value);
        }
    }
}
