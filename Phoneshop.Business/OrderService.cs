using Microsoft.EntityFrameworkCore;
using Phoneshop.Domain.Entities;
using Phoneshop.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Phoneshop.Business
{
    public class OrderService : IOrderService
    {
        private readonly IRepository<Order> _repository;

        public OrderService(IRepository<Order> repository)
        {
            _repository = repository;
        }

        public void Delete(int id, string userId)
        {
            var requestOrder = _repository.GetById(id);
            if (requestOrder == null)
            {
                throw new Exception("This Order does not exist!");
            }
            if (requestOrder.CustomerId != userId)
            {
                throw new Exception($"Order does not belong to customer: {requestOrder.CustomerId}");
            }

            requestOrder.Deleted = true;
            requestOrder.Reason = 1;
            _repository.SaveChanges();
            
        }

        public Order Get(int id, string userId)
        {
            var requestOrder = _repository.GetById(id);
            if (requestOrder.CustomerId != userId)
            {
                throw new Exception($"Order does not belong to customer: {requestOrder.CustomerId}");
            }

            return requestOrder;
        }

        public IEnumerable<Order> GetAllLoggedInUser(string userId)
        {
            return _repository.GetAll().Where(x => x.CustomerId == userId);
        }

        public void Create(Order order)
        {
            _repository.Create(order);
        }

        public IEnumerable<Order> GetAll()
        {
            return _repository.GetAll().Include(x => x.ProductsPerOrder).ThenInclude(x => x.Product);
        }
    }
}
