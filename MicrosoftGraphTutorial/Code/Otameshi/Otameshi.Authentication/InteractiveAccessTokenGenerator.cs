using System.Linq;
using System.Threading.Tasks;
using Microsoft.Identity.Client;
using Otameshi.Core;

namespace Otameshi.Authentication
{
    public class InteractiveAccessTokenGenerator : IAccessTokenGenerator
    {
        private readonly IPublicClientApplication msalClient;

        public InteractiveAccessTokenGenerator()
        {
            msalClient = PublicClientApplicationBuilder
                .Create("93c693fb-d9ce-42f5-b869-81d440dae5ff")
                .WithDefaultRedirectUri()
                .Build();
        }

        public async Task<string> GenerateAsync()
        {
            var scopes = new[] { "User.Read" };

            var accounts = await msalClient.GetAccountsAsync();
            var account = accounts.FirstOrDefault();

            AuthenticationResult result;

            try
            {
                result = await msalClient.AcquireTokenSilent(scopes, account).ExecuteAsync();
            }
            catch (MsalUiRequiredException)
            {
                result = await msalClient.AcquireTokenInteractive(scopes).ExecuteAsync();
            }

            return result.AccessToken;
        }
    }
}
