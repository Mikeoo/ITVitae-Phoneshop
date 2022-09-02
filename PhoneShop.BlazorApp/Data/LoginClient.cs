using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PhoneShop.api.Models;
using Phoneshop.Domain.Entities;

namespace PhoneShop.BlazorApp.Data
{
    public class LoginClient : MyHttpClient, ILoginClient
    {
        public async Task<LoginApiResponse> Login(LoginCredentials loginCredentials)
        {
            var result = await PostRequest<LoginCredentials>("/LoginJwt", loginCredentials);
            return JsonConvert.DeserializeObject<LoginApiResponse>(result);

        }
    }
}
