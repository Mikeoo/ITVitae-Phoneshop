using FluentAssertions;
using Moq;
using Phoneshop.Domain.Entities;
using System;
using Xunit;

// ReSharper disable once CheckNamespace
namespace BrandServiceTests
{
    public class GetById : Base
    {
        [Fact]
        public void Should_Return_Exception()
        {
            Action action = () => brandService.Get(0);

            action.Should().Throw<Exception>().WithMessage("Id cannot be < 1");
        }

        [Fact]
        public void Should_Return_Brand_By_Id()
        {
            // Arrange
            mockedBrandRepository.Setup(x => x.GetById(It.IsAny<int>())).Returns(new Brand() { Id = 15, Name = "LG" });

            // Act & Assert
            brandService.Get(15).Name.Should().Be("LG");
            brandService.Get(15).Should().BeOfType<Brand>();
        }
    }
}