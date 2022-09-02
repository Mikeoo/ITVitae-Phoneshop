using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Phoneshop.Domain.Entities;
using Phoneshop.Domain.Interfaces;

namespace Phoneshop.Business.Tests.OrderServiceTests
{
    public class Base
    {
        public readonly OrderService OrderService;
        public Mock<IRepository<Order>> MockedOrderRepository;
        public Mock<ILoggerService> MockedLoggerService;
        public Mock<IBrandService> MockedBrandService;
        public Mock<IOrderService> MockedOrderService;

        public Base()
        {
            MockedOrderService = new Mock<IOrderService>();
            MockedBrandService = new Mock<IBrandService>();
            MockedOrderRepository = new Mock<IRepository<Order>>();
            MockedLoggerService = new Mock<ILoggerService>();
            OrderService = new OrderService(MockedOrderRepository.Object);
        }
    }
}
