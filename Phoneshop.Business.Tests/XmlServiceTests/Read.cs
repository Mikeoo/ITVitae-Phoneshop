using Moq;
using Phoneshop.Business;
using Phoneshop.Domain.Interfaces;
using System;
using System.IO;
using Xunit;

// ReSharper disable once CheckNamespace
namespace XmlServiceTests
{
    public class Read
    {
        private readonly XmlService _xmlService;

        public Read()
        {
            _xmlService = new XmlService(new Mock<IBrandService>().Object);
        }

        [Fact]
        public void Should_ThrowArgumentNullException_When_XmlIsNull()
        {
            void Action() => _xmlService.Read(null);
            var exception = Assert.Throws<ArgumentNullException>(Action);

            Assert.Equal("Value cannot be null. (Parameter 'xml')", exception.Message);
        }

        [Fact]
        public void Should_ReadXmlAndReturnPhones()
        {
            using TextReader reader = new StreamReader("PhoneList001.xml");
            var phones = _xmlService.Read(reader);

            Assert.Equal(4, phones.Count);
        }
    }
}