using System.Threading.Tasks;
using PhoneShop.api.Models;
using Phoneshop.Domain.Entities;

namespace PhoneShop.BlazorApp.Helpers
{
    public interface IAuthService
    {
        Task<LoginApiResponse> Register(UserDetails registerModel);
        Task<LoginApiResponse> Login(LoginCredentials loginModel);
        Task Logout();
    }
}