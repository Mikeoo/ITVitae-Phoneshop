using FluentAssertions;
using Moq;
using Phoneshop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using PhoneServiceTests;
using Xunit;

namespace Phoneshop.Business.Tests.PhoneServiceTests
{
    public class SaveChanges : Base
    {
        [Fact]
        public void Should_ThrowArgumentNullException_When_QueryIsEmpty()
        {
            // Act
            Action f = () => PhoneService.SaveChanges();
            f.Invoke();
            // Assert
            MockedPhoneRepository.Verify(x => x.SaveChanges(), Times.Once);

        }
    }
}
