using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Authorization;

namespace PhoneShop.BlazorApp.Helpers
{
    public interface IApiAuthenticationStateProvider
    {
        Task<AuthenticationState> GetAuthenticationStateAsync();
        void MarkUserAsAuthenticated(string email);
        void MarkUserAsLoggedOut();
        event AuthenticationStateChangedHandler AuthenticationStateChanged;
    }
}