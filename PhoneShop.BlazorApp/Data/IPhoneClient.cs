using System.Collections.Generic;
using System.Threading.Tasks;
using Phoneshop.Domain.Entities;

namespace PhoneShop.BlazorApp.Data
{
    public interface IPhoneClient
    {
        Task<IEnumerable<Phone>> GetAll();
        Task<Phone> GetById(int id);
    }
}