using FluentAssertions;
using Phoneshop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace PhoneServiceTests
{
    public class Search : Base
    {
        [Fact]
        public void Should_ReturnResults_When_QueryIsCamera()
        {
            // Arrange
            MockedPhoneRepository.Setup(x => x.GetAll()).Returns(new List<Phone>
            {
                new () { Id = 1, Type = "Police", Description ="Description 1", Brand = new Brand { Id = 1, Name = "Herp"}},
                new () { Id = 2, Type = "Fireman", Description ="Description 2", Brand = new Brand { Id = 2, Name = "Herp"}},
                new () { Id = 3, Type = "Nurse", Description ="Description 3", Brand = new Brand { Id = 3, Name = "Zerp"}},
                new () { Id = 4, Type = "Doctor", Description ="Description 4", Brand = new Brand { Id = 4, Name = "Flurp"}},
            }.AsQueryable());

            // Act & Assert
            PhoneService.Search("Description").ToList().Should().HaveCount(4);
            PhoneService.Search("DeScRipTioN").ToList().Should().HaveCount(4);
            PhoneService.Search("Fireman").ToList().Should().HaveCount(1);
            PhoneService.Search("Herp").ToList().Should().HaveCount(2);
            PhoneService.Search("aaafafa").ToList().Should().HaveCount(0);
        }

        [Fact]
        public void Should_ThrowArgumentNullException_When_QueryIsEmpty()
        {
            // Act
            Action f = () => PhoneService.Search(string.Empty);

            // Assert
            f.Should().Throw<Exception>().WithMessage("Query cannot be empty");
        }
    }
}