using FluentAssertions;
using Moq;
using Phoneshop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

// ReSharper disable once CheckNamespace
namespace PhoneServiceTests
{
    public class Delete : Base
    {
        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        public void Should_Exception_When_IdIsInvalid(int id)
        {
            Action a = () => PhoneService.Delete(id);
            a.Should().Throw<Exception>().WithMessage("The value id has to be bigger than 0");
        }

        [Fact]
        public void Should_Delete_Phone_And_Brand()
        {
            MockedPhoneRepository.Setup(x => x.GetById(It.IsAny<int>())).Returns(new Phone()
            {
                Id = 1,
                BrandId = 2,
                Type = "MockType",
                Brand = new Brand
                {
                    Name = "BrandOne",
                    Id = 2
                }
            });
            PhoneService.Delete(1);

            MockedPhoneRepository.Verify(x => x.Delete(It.IsAny<int>()), Times.Once);
            MockedBrandService.Verify(x => x.Delete(It.IsAny<int>()), Times.Once);
        }

        [Fact]
        public void Should_Delete_Phone_Only()
        {
            MockedPhoneRepository.Setup(x => x.GetById(It.IsAny<int>())).Returns(new Phone()
            {
                Id = 1,
                BrandId = 2,
                Type = "MockType",
                Brand = new Brand
                {
                    Name = "BrandOne",
                    Id = 2
                }
            });

            MockedPhoneRepository.Setup(x => x.GetAll()).Returns(new List<Phone>
            {
                new () { Id = 2, Type = "Police", Description = "Description 1", BrandId = 2, Brand = new Brand { Id = 2, Name = "BrandOne"}},
                new () { Id = 3, Type = "Fireman", Description = "Description 2", BrandId = 3, Brand = new Brand { Id = 2, Name = "Derp"}},
                new () { Id = 4, Type = "Nurse", Description =" Description 3", BrandId = 4, Brand = new Brand { Id = 3, Name = "Zerp"}}
            }.AsQueryable());
            PhoneService.Delete(1);

            MockedPhoneRepository.Verify(x => x.Delete(It.IsAny<int>()), Times.Once);
            MockedBrandService.Verify(x => x.Delete(It.IsAny<int>()), Times.Never);
        }
    }
}