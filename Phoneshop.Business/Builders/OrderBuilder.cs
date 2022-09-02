using Phoneshop.Domain.Entities;
using Phoneshop.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Phoneshop.Business.Builders
{
    public class OrderBuilder : IOrderBuilder
    {
        // https://medium.com/@martinstm/fluent-builder-pattern-c-4ac39fafcb0b
        // https://medium.com/@jacobcunningham/the-fluent-builder-pattern-ac1b6c23afc3
        private readonly Order _order = new();

        public OrderBuilder()
        {
            _order.ProductsPerOrder = new List<ProductPerOrder>();
        }

        public Order Build() => _order;
        public IOrderBuilder AddPhone(Phone phone)
        {
            if (_order.ProductsPerOrder.All(x => x.Product.Id != phone.Id))
            {
                _order.ProductsPerOrder.Add(new ProductPerOrder()
                {
                    Amount = 1,
                    Product = phone
                });
            }
            else
            {
                _order.ProductsPerOrder.FirstOrDefault(x => x.Product.Id == phone.Id)!.Amount++;
            }

            return this;
        }

        public IOrderBuilder AddPhones(IEnumerable<Phone> phones)
        {

            foreach (var phone in phones)
            {
                {
                    AddPhone(phone);
                }
            }
            return this;
        }

        public IOrderBuilder SetTotalPrice(double totalPrice)
        {
            _order.TotalPrice = totalPrice;
            return this;
        }

        public IOrderBuilder SetVatPercentage(double vatPercentage)
        {
            _order.VatPercentage = vatPercentage;
            return this;
        }

        public IOrderBuilder SetCustomerId(string customerId)
        {
            _order.CustomerId = customerId;
            return this;
        }
    }
}
