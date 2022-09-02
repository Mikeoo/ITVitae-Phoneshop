using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PhoneShop.api.Models;
using Phoneshop.Domain.Entities;

namespace PhoneShop.BlazorApp.Data
{
    public interface ILoginClient
    {
        Task<LoginApiResponse> Login(LoginCredentials loginCredentials);
    }
}