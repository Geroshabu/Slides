using System.Threading.Tasks;
using Microsoft.Graph;
using Otameshi.Core;

namespace Otameshi.GraphApi
{
    public class UserRepository
    {
        private readonly GraphServiceClient graphClient;

        public UserRepository(IAccessTokenGenerator generator)
        {
            graphClient = new GraphServiceClient(new AuthenticationProvider(generator));
        }

        public async Task<Core.User> GetMeAsync()
        {
            var sdkUser = await graphClient.Me.Request().GetAsync();

            return new Core.User(sdkUser.DisplayName, sdkUser.MobilePhone, sdkUser.JobTitle);
        }
    }
}
