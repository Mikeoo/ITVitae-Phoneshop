using FluentAssertions;
using Moq;
using Phoneshop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

// ReSharper disable once CheckNamespace
namespace BrandServiceTests
{
    public class Create : Base
    {
        [Fact]
        public void Create_Should_Create_Brand()
        {
            //arrange
            mockedBrandRepository.Setup(x => x.Create(It.IsAny<Brand>())).Verifiable();
            var brand = new Brand
            {
                Name = "Apple",
                Id = 1
            };
            //act
            brandService.Create(brand);

            //assert
            mockedBrandRepository.VerifyAll();
        }

        [Fact]
        public void Brand_Without_Name_Should_Throw_Exception()
        {
            //Arrange
            var brand = new Brand
            {
                Name = "",
                Id = 1
            };
            Action action = () => brandService.Create(brand);

            //Act & Assert
            action.Should().Throw<Exception>().WithMessage("brand can not be null or empty");
        }

        [Fact]
        public void Adding_Existing_Brand_Should_Throw_Exception()
        {
            // Arrange
            var brand = new Brand
            {
                Name = "Samsung",
                Id = 1
            };
            mockedBrandRepository.Setup(x => x.GetAll()).Returns(new List<Brand> { brand }.AsQueryable());
            Action action = () => brandService.Create(brand);

            //Act & Assert
            action.Should().Throw<Exception>().WithMessage("Brand name already in the database");
        }
    }
}