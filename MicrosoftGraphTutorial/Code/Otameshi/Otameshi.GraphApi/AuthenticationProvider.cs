using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.Graph;
using Otameshi.Core;

namespace Otameshi.GraphApi
{
    public class AuthenticationProvider : IAuthenticationProvider
    {
        private readonly IAccessTokenGenerator generator;

        public AuthenticationProvider(IAccessTokenGenerator generator)
        {
            this.generator = generator;
        }
        
        public async Task AuthenticateRequestAsync(HttpRequestMessage request)
        {
            var accessToken = await generator.GenerateAsync();

            request.Headers.Authorization
                = new AuthenticationHeaderValue("bearer", accessToken);
        }
    }
}
