using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using Phoneshop.Domain.Entities;
using Xunit;
using Xunit.Sdk;

namespace Phoneshop.Business.Tests.OrderServiceTests
{
    public class Delete : Base
    {
        [Theory]
        [InlineData(-1, "123")]
        [InlineData(0, "123")]
        public void Should_Exception_When_IdIsInvalid(int id,string userId)
        {
            Action a = () => OrderService.Delete(id, userId);
            a.Should().Throw<Exception>().WithMessage("This Order does not exist!");
        }

        [Fact]
        public void Should_Delete_Phone_And_Brand()
        {
            MockedOrderRepository.Setup(x => x.GetById(It.IsAny<int>())).Returns(new Order()
            {
                Id = 1,
                CustomerId = "123",
                Deleted = true
            });
            OrderService.Delete(1, "123");
            var product = OrderService.Get(1, "123");

            product.Deleted.Should().Be(true);
        }
    }
}
