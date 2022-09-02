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
    public class Create : Base
    {
        [Fact]
        public void Should_ThrowException_When_BrandAndTypeExists()
        {
            // Arrange
            MockedPhoneRepository.Setup(x => x.GetAll()).Returns(new List<Phone>
            {
                new () { Id = 1, Type = "Testing", Description ="Description 1", Brand = new Brand { Id = 1, Name = "Test"}},
            }.AsQueryable());

            // Act & Assert
            Action a = () => PhoneService.Create(new Phone
            {
                Brand = new Brand
                {
                    Name = "Test"
                },
                Type = "Testing",
                Description = "Description 1",
                
            });

            MockedPhoneRepository.Verify(x => x.Create(It.IsAny<Phone>()), Times.Never);
        }

        [Fact]
        public void Should_CreatePhone_If_Brand_Exists_But_Type_Not()
        {
            MockedPhoneRepository.Setup(x => x.GetAll()).Returns(new List<Phone>
            {
                new () { Id = 1, Type = "Testing", Description ="Description 1", Brand = new Brand { Id = 1, Name = "Test"}},
            }.AsQueryable());

            MockedBrandService.Setup(x => x.CheckIfExists(It.IsAny<Brand>())).Returns(false);
            PhoneService.Create(new Phone
            {
                Brand = new Brand
                {
                    Name = "Test"
                },
                Type = "SecondFromBrand",
                Description = "test2",
                Price = 1000,
                Stock = 2
            });

            MockedPhoneRepository.Verify(x => x.Create(It.IsAny<Phone>()), Times.Once);
        }

        [Fact]
        public void Should_Get_Existing_Brand_Id_And_Create_Phone()
        {
            MockedPhoneRepository.Setup(x => x.GetAll()).Returns(new List<Phone>
            {
                new () { Id = 1, Type = "Police", Description ="Description 1", Brand = new Brand { Id = 1, Name = "Herp"}},
                new () { Id = 2, Type = "Fireman", Description ="Description 2", Brand = new Brand { Id = 2, Name = "Herp"}},
                new () { Id = 3, Type = "Nurse", Description ="Description 3", Brand = new Brand { Id = 3, Name = "Zerp"}},
                new () { Id = 4, Type = "Doctor", Description ="Description 4", Brand = new Brand { Id = 4, Name = "Flurp"}},
            }.AsQueryable());
            MockedBrandService.Setup(x => x.GetByName(It.IsAny<string>())).Returns(new Brand() { Id = 1, Name = "Test" }
            );

            MockedBrandService.Setup(x => x.CheckIfExists(It.IsAny<Brand>())).Returns(true);
            var phone = new Phone
            {
                Type = "NewType",
                Brand = new Brand { Name = "Herp" }
            };

            PhoneService.Create(phone);
            MockedPhoneRepository.Verify(x => x.Create(It.IsAny<Phone>()), Times.Once);
        }
    }
}