using System.Collections.Generic;
using System.Threading.Tasks;
using Phoneshop.Domain.Entities;

namespace Phoneshop.Domain.Interfaces
{
    public interface IApiService
    {
        IEnumerable<Phone> GetAll();
    }
}
