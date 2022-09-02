using System.Threading.Tasks;
using PhoneShop.api.Models;
using Phoneshop.Domain.Entities;

namespace PhoneShop.BlazorApp.Data
{
    public interface IRegisterClient
    {
        Task<LoginApiResponse> Register(UserDetails userDetails);

    }
}