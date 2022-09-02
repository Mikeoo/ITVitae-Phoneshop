using Phoneshop.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Phoneshop.Domain.Interfaces
{
    public interface IScraper
    {
        bool CanExecute(string url);
        public Task<IEnumerable<Phone>> Execute(string url);
    }
}
