using System;
using System.Threading.Tasks;

namespace Phoneshop.Domain.Interfaces
{
    public interface ICaching
    {
        Task<TItem> GetOrCreate<TItem>(string key, Func<TItem> createItem);
    }
}
