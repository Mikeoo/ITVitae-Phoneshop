using Phoneshop.Domain.Entities;
using System.Collections.Generic;

namespace Phoneshop.Domain.Interfaces
{
    public interface IBrandService
    {
        Brand Create(Brand brand);

        Brand Get(int id);

        Brand GetByName(string name);

        void Delete(int id);

        IEnumerable<Brand> Get();

        Brand GetOrCreate(string Brand);

        bool CheckIfExists(Brand Brand);
    }
}