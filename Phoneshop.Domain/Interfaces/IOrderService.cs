using Phoneshop.Domain.Entities;
using System.Collections.Generic;

namespace Phoneshop.Domain.Interfaces
{
    public interface IOrderService
    {
        void Delete(int id, string userId);
        Order Get(int id, string userId);
        IEnumerable<Order> GetAllLoggedInUser(string userId);
        void Create(Order order);
        IEnumerable<Order> GetAll();
    }
}
