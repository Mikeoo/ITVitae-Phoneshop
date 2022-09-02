using Moq;
using Phoneshop.Domain.Entities;
using System.Collections.Generic;
using Xunit;

// ReSharper disable once CheckNamespace
namespace PhoneServiceTests
{
    public class CreatePhoneList : Base
    {
        [Fact]
        public void Should_Return_List_Of_Phones()
        {
            MockedPhoneRepository.Setup(x => x.Create(It.IsAny<Phone>()));

            var list = new List<Phone>()
            {
                new() { Id = 1, Type = "Test", BrandId = 1, Brand = new Brand {  Id = 1, Name = "Brand1"}},
                new() { Id = 2, Type = "Test", BrandId = 2, Brand = new Brand {  Id = 2, Name = "Brand2"}}
            };

            PhoneService.Create(list);
            Assert.Equal(2, list.Count);
        }
    }
}