using FluentAssertions;
using Moq;
using Phoneshop.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using Xunit;

// ReSharper disable once CheckNamespace
namespace BrandServiceTests
{
    public class CheckIfExists : Base
    {
        [Fact]
        public void Should_Return_True()
        {
            // Arrange
            mockedBrandRepository.Setup(x => x.GetById(It.IsAny<int>())).Returns(new Brand
            {
                Id = 1,
                Name = "Herp",
            });

            mockedBrandRepository.Setup(x => x.GetAll()).Returns(new List<Brand>
            {
                new ()
                {
                    Id = 1,
                    Name = "Herp"
                }
            }.AsQueryable());
            // Act
            var fakeBrand = brandService.Get(1);
            var check = brandService.CheckIfExists(fakeBrand);
            // Assert
            check.Should().Be(true);
        }

        [Fact]
        public void Should_Return_False()
        {
            // Arrange
            var fakeBrand = brandService.Get(2);
            var check = brandService.CheckIfExists(fakeBrand);

            // Act &Assert
            check.Should().Be(false);
        }
    }
}