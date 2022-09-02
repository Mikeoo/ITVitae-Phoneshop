using System.Text.RegularExpressions;

namespace PhoneShop.BlazorApp.Data
{
    public class ApiClient : IApiClient
    {
        public ApiClient(IPhoneClient phoneClient, ILoginClient loginClient, IRegisterClient registerClient)
        {
            PhoneClient = phoneClient;
            LoginClient = loginClient;
            RegisterClient = registerClient;
        }

        public IPhoneClient PhoneClient { get; }
        public ILoginClient LoginClient { get; }
        public IRegisterClient RegisterClient { get; }

    }
}