using Phoneshop.Domain.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace Phoneshop.Business.Repositories
{
    // ReSharper disable once InconsistentNaming
    public class EFRepository<T> : IRepository<T> where T : class, IEntity
    {
        private readonly DataContext _dataContext;

        public EFRepository(DataContext context)
        {
            _dataContext = context;
        }

        public T Create(T entity)
        {
            _dataContext.Set<T>().Add(entity);
            _dataContext.SaveChanges();
            return entity;
        }

        public void Delete(int id)
        {
            var item = GetById(id);
            _dataContext.Remove(item);

            _dataContext.SaveChanges();
        }

        public void SaveChanges()
        {
            _dataContext.SaveChanges();
        }

        public IQueryable<T> GetAll()
        {
            return _dataContext.Set<T>();
        }

        public T GetById(int id)
        {
            return _dataContext.Set<T>().FirstOrDefault(x => x.Id == id);
        }
    }
}