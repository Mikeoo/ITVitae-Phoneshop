using System.Collections.Generic;
using System.Threading.Tasks;
using Phoneshop.Domain.Entities;

namespace PhoneShop.BlazorApp.Data
{
    public interface IBrandClient
    {
        Task<IEnumerable<Brand>> GetAll();
        Task<Brand> GetById(int id);
    }
}