using FluentAssertions;
using Phoneshop.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using Xunit;

// ReSharper disable once CheckNamespace
namespace BrandServiceTests
{
    public class Get : Base
    {
        [Fact]
        public void Start()
        {
            mockedBrandRepository.Setup(x => x.GetAll()).Returns(new List<Brand>
            {
                new() { Id = 1, Name = "Herp"},
                new() { Id = 5, Name = "Terp"}
            }.AsQueryable());
            brandService.Get().Should().HaveCount(2);
        }
    }
}