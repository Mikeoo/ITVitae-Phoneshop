using Moq;
using Phoneshop.Business;
using Phoneshop.Domain.Entities;
using Phoneshop.Domain.Interfaces;

namespace PhoneServiceTests
{
    public class Base
    {
        public readonly PhoneService PhoneService;
        public Mock<IRepository<Phone>> MockedPhoneRepository;
        public Mock<ILoggerService> MockedLoggerService;
        public Mock<IBrandService> MockedBrandService;

        public Base()
        {
            MockedBrandService = new Mock<IBrandService>();
            MockedPhoneRepository = new Mock<IRepository<Phone>>();
            MockedLoggerService = new Mock<ILoggerService>();
            PhoneService = new PhoneService(MockedPhoneRepository.Object, MockedBrandService.Object, MockedLoggerService.Object);
        }
    }
}