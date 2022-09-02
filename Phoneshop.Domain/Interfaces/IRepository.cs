using System.Linq;
using System.Threading.Tasks;

namespace Phoneshop.Domain.Interfaces
{
    public interface IRepository<T> where T : class, IEntity
    {
        IQueryable<T> GetAll();

        T GetById(int id);

        T Create(T entity);

        void Delete(int id);

        void SaveChanges();
    }
}