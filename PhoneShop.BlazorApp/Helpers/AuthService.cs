using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server;
using PhoneShop.api.Models;
using Phoneshop.Domain.Entities;
using ApiClientLibary;

namespace PhoneShop.BlazorApp.Helpers
{
    public class AuthService : IAuthService
    {
        private readonly HttpClient _httpClient;
        private readonly ServerAuthenticationStateProvider _authenticationStateProvider;
        private readonly ILocalStorageService _localStorage;
        private readonly IApiClient _apiClient;

        public AuthService(HttpClient httpClient,
            ServerAuthenticationStateProvider authenticationStateProvider,
            ILocalStorageService localStorage,
            IApiClient apiClient)
        {
            _httpClient = httpClient;
            _authenticationStateProvider = authenticationStateProvider;
            _localStorage = localStorage;
            _apiClient = apiClient;
        }

        public async Task<LoginApiResponse> Register(UserDetails registerModel)
        {
            var result = await _apiClient.PostRequest<LoginApiResponse>("/RegisterJwt", registerModel);

            return result;
        }

        public async Task<LoginApiResponse> Login(LoginCredentials loginModel)
        {
            var response = await _apiClient.PostRequest<LoginApiResponse>("/LoginJwt", loginModel);

            if (string.IsNullOrEmpty(response.Token))
            {
                return response;
            }

            await _localStorage.SetItemAsync("authToken", response.Token);
            ((ApiAuthenticationStateProvider)_authenticationStateProvider).MarkUserAsAuthenticated(loginModel.Username);
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", response.Token);

            return response;
        }

        public async Task Logout()
        {
            await _localStorage.RemoveItemAsync("authToken");
            ((ApiAuthenticationStateProvider)_authenticationStateProvider).MarkUserAsLoggedOut();
            _httpClient.DefaultRequestHeaders.Authorization = null;
        }
    }
}
