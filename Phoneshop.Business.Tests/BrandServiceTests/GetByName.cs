using FluentAssertions;
using Phoneshop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

// ReSharper disable once CheckNamespace
namespace BrandServiceTests
{
    public class GetByName : Base
    {
        [Fact]
        public void Should_Return_Brand_By_Name()
        {
            // Arrange
            mockedBrandRepository.Setup(x => x.GetAll()).Returns(new List<Brand>
            {
                new() { Id = 1, Name = "Herp"},
                new() { Id = 5, Name = "Terp"}
            }.AsQueryable());

            //Act
            var brandName = brandService.GetByName("Herp");
            var brandName2 = brandService.GetByName("Terp");
            //Assert
            brandName.Id.Should().Be(1);
            brandName2.Id.Should().Be(5);
        }

        [Fact]
        public void Should_Throw_Exception_When_Name_Is_Null()
        {
            Action a = () => brandService.GetByName(string.Empty);
            Action a1 = () => brandService.GetByName(null);

            a.Should().Throw<Exception>().WithMessage("name cannot be null");
            a1.Should().Throw<Exception>().WithMessage("name cannot be null");
        }
    }
}