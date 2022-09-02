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
    public class GetById : Base
    {
        [Fact]
        public void Should_ReturnASinglePhone()
        {
            // Arrange
            MockedPhoneRepository.Setup(x => x.GetAll()).Returns(new List<Phone>
            {
                new () { Id = 1, Type = "Police", Description ="Description 1", Brand = new Brand { Id = 1, Name = "Herp"}},
                new () { Id = 2, Type = "Fireman", Description ="Description 2", Brand = new Brand { Id = 2, Name = "Derp"}},
                new () { Id = 3, Type = "Nurse", Description ="Description 3", Brand = new Brand { Id = 3, Name = "Zerp"}},
                new () { Id = 4, Type = "Doctor", Description ="Description 4", Brand = new Brand { Id = 4, Name = "Flurp"}},
                new () { Id = 5, Type = "Teacher", Description ="Description 5", Brand = new Brand { Id = 5, Name = "Terp"}}
            }.AsQueryable());

            // Assert
            PhoneService.Get(1).Type.Should().Be("Police");
        }

        [Fact]
        public void Should_ReturnNull_When_PhoneIsNotFound()
        {
            // Act & Assert
            PhoneService.Get(9).Should().BeNull();
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-15)]
        public void Should_Throw_Exception(int id)
        {
            Action a = () => PhoneService.Get(id);
            a.Should().Throw<Exception>().WithMessage("The value of Id to be bigger than 0");
        }
    }
}