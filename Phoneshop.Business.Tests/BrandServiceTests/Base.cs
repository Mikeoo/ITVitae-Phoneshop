using Moq;
using Phoneshop.Business;
using Phoneshop.Domain.Entities;
using Phoneshop.Domain.Interfaces;

// ReSharper disable once CheckNamespace
namespace BrandServiceTests
{
    public class Base
    {
        public readonly BrandService brandService;
        public Mock<IRepository<Brand>> mockedBrandRepository;
        public Mock<ILoggerService> MockedLoggerService;

        public Base()
        {
            mockedBrandRepository = new Mock<IRepository<Brand>>();
            MockedLoggerService = new Mock<ILoggerService>();

            brandService = new BrandService(mockedBrandRepository.Object, MockedLoggerService.Object);


        }
    }
}