using Microsoft.EntityFrameworkCore;
using NLog;
using Phoneshop.Domain.Entities;
using Phoneshop.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Phoneshop.Business
{
    public class PhoneService : IPhoneService
    {
        private readonly IRepository<Phone> _repository;
        private readonly IBrandService _brandService;
        private readonly ILoggerService _loggerService;

        private readonly Logger _searchLogger = LogManager.GetLogger("searchlogger");
        private readonly Logger _infoLogger = LogManager.GetLogger("infologger");
        private readonly Logger _errorLogger = LogManager.GetLogger("errorlogger");



        public PhoneService(IRepository<Phone> repository, IBrandService brandService, ILoggerService loggerService)
        {
            _repository = repository;
            _brandService = brandService;
            _loggerService = loggerService;
        }

        public void Create(Phone phone)
        {
            if (CheckIfExists(phone))
            {
                _errorLogger.Error($"{phone.FullName} already exists");
            }

            var exists = _brandService.CheckIfExists(phone.Brand);
            if (!exists)
            {
                _repository.Create(phone);
            }
            else
            {
                phone.BrandId = _brandService.GetByName(phone.Brand.Name).Id;
                phone.Brand = null;
                _repository.Create(phone);
            }
            _infoLogger.Info($"Created {phone.FullName} by {Environment.MachineName}");
        }

        public bool CheckIfExists(Phone phone)
        {
            return _repository.GetAll().Where(x => x.Brand.Name == phone.Brand.Name).Any(x => x.Type == phone.Type);
        }

        public void SaveChanges()
        {
            _repository.SaveChanges();
        }

        public void Create(List<Phone> phones)
        {
            foreach (var item in phones)
            {
                Create(item);
            }
        }

        public void Delete(int id)
        {
            if (id <= 0)
            {
                _errorLogger.Error($"The value id has to be bigger than 0 but was {id}");
                throw new Exception("The value id has to be bigger than 0");
            }
            var deletingPhone = _repository.GetById(id);
            var brandId = deletingPhone.BrandId;
            _repository.Delete(id);
            var stillInUse = _repository.GetAll().Any(x => x.BrandId == brandId);

            if (!stillInUse)
            {
                _brandService.Delete(brandId);
            }
            _infoLogger.Info($"{deletingPhone.FullName} deleted by {Environment.MachineName}");

        }

        public Phone Get(int id)
        {
            if (id <= 0)
            {
                _loggerService.LogError($"The value id has to be bigger than 0 but was {id}");
                throw new Exception($"The value of Id to be bigger than 0");
            }

            return GetAll().SingleOrDefault(x => x.Id == id);
        }

        public IEnumerable<Phone> GetAll()
        {
            return _repository.GetAll().Include(x => x.Brand);
        }

        public IEnumerable<Phone> Search(string query)
        {
            if (string.IsNullOrEmpty(query))
            {
                _errorLogger.Error($"Query cannot be empty");
                throw new Exception("Query cannot be empty");
            }

            var lowerCaseQuery = query.ToLower();

            _searchLogger.Info($"Searched for : {query}");

            return GetAll().Where(phone =>
            phone.Brand.Name.ToLower().Contains(lowerCaseQuery) ||
            phone.Description.ToLower().Contains(lowerCaseQuery) ||
            phone.Type.ToLower().Contains(lowerCaseQuery));
        }
    }
}