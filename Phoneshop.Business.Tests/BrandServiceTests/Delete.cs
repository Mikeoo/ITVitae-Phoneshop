using FluentAssertions;
using Moq;
using System;
using Xunit;

// ReSharper disable once CheckNamespace
namespace BrandServiceTests
{
    public class Delete : Base
    {
        [Fact]
        public void Delete_Should_Delete_Phone()
        {
            //arrange
            mockedBrandRepository.Setup(x => x.Delete(It.IsAny<int>())).Verifiable();

            //act
            brandService.Delete(1);

            //assert
            mockedBrandRepository.VerifyAll();
        }

        [Fact]
        public void Should_Throw_Exception()
        {
            Action action = () => brandService.Delete(-1);

            action.Should().Throw<Exception>().WithMessage("Id cannot be < 1 ");
        }
    }
}