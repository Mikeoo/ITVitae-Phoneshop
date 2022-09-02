using Phoneshop.Domain.Entities;
using System.Collections.Generic;

namespace Phoneshop.Domain.Interfaces
{
    public interface IOrderBuilder
    {
        Order Build();
        IOrderBuilder AddPhone(Phone phone);
        IOrderBuilder AddPhones(IEnumerable<Phone> phones);
        IOrderBuilder SetTotalPrice(double totalPrice);
        IOrderBuilder SetVatPercentage(double vatPercentage);
        IOrderBuilder SetCustomerId(string customerId);
    }
}
