using Phoneshop.Business.Extensions;
using Phoneshop.Domain.Entities;
using Xunit;

namespace ExtensionsTests
{
    public class PhoneExtensions
    {
        [Fact]
        public void Should_CalculatePriceWithoutVat()
        {
            var phone = new Phone()
            {
                Price = 121
            };

            var price = phone.PriceWithoutVat();

            Assert.Equal(100, price);
        }
    }
}