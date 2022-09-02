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
    public class GetOrCreate : Base
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void Should_Exception_When_NameIsInvalid(string value)
        {
            Action a = () => brandService.GetOrCreate(value);
            a.Should().Throw<Exception>().WithMessage("name cannot be null");
        }

        [Fact]
        public void ShouldGetBrand()
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

            // Assert
            var fakeBrand = brandService.GetOrCreate("Herp");

            mockedBrandRepository.Verify(x => x.Create(fakeBrand), Times.Never);
            brandService.GetByName(fakeBrand.Name).Should().BeOfType<Brand>().Which.Id.Should().Be(1);
        }

        [Fact]
        public void ShouldCreateBrand()
        {
            mockedBrandRepository.Setup(x => x.Create(It.IsAny<Brand>()));
            brandService.GetOrCreate("brand");
            mockedBrandRepository.Verify(x => x.Create(It.IsAny<Brand>()), Times.Once());
        }
    }
}