using System.Threading.Tasks;
using Newtonsoft.Json;
using PhoneShop.api.Models;
using Phoneshop.Domain.Entities;

namespace PhoneShop.BlazorApp.Data
{
    public class RegisterClient : MyHttpClient, IRegisterClient
    {

        public async Task<LoginApiResponse> Register(UserDetails userDetails)
        {
            var result = await PostRequest("/RegisterJwt", userDetails);
            return JsonConvert.DeserializeObject<LoginApiResponse>(result);
        }
    }
}