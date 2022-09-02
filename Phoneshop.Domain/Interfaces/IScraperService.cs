using Phoneshop.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Phoneshop.Domain.Interfaces
{
    public interface IScraperService
    {
        public Task<List<Phone>> GetPhones(IEnumerable<IScraper> allScrapers);
        public Task<List<Phone>> AddPhones(List<Phone> phones);
    }
}
