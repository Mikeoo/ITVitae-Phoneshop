using NLog;
using Phoneshop.Domain.Entities;
using Phoneshop.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Phoneshop.Business
{
    public class BrandService : IBrandService
    {
        private readonly IRepository<Brand> _repository;
        private readonly ILoggerService _loggerService;

        private readonly Logger _infoLogger = LogManager.GetLogger("infologger");
        private readonly Logger _errorLogger = LogManager.GetLogger("errorlogger");

        public BrandService(IRepository<Brand> brandRepository, ILoggerService loggerService)
        {
            _repository = brandRepository;
            _loggerService = loggerService;
        }

        public Brand Create(Brand brand)
        {
            if (string.IsNullOrEmpty(brand.Name))
            {
                _errorLogger.Error("Brand name cannot be empty");
                throw new Exception("Brand can not be null or empty");
            }

            if (GetByName(brand.Name) != null)
            {
                _errorLogger.Error($"{brand.Name} already exists with id {brand.Id}");
                throw new Exception($"Brand name already in the database");
            }
            _infoLogger.Info($"Created {brand.Name} by {Environment.MachineName}");
            return _repository.Create(brand);
        }

        public void Delete(int id)
        {
            if (id <= 0)
            {
                _errorLogger.Error($"id cannot be < 1");
                throw new Exception("Id cannot be < 1 ");
            }
            _repository.Delete(id);
            _infoLogger.Info($"Deleted brand with id:{id} by {Environment.MachineName}");

        }

        public Brand GetByName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                _errorLogger.Error($"{name} cannot be null or empty");
                throw new Exception("name cannot be null");
            }

            return _repository.GetAll().FirstOrDefault(x => x.Name == name);
        }

        public Brand Get(int id)
        {
            if (id < 1)
            {
                _errorLogger.Error($"{id} cannot be 0 or negative");
                throw new ArgumentException("Id cannot be < 1");
            }

            return _repository.GetById(id);
        }

        public IEnumerable<Brand> Get()
        {
            return _repository.GetAll();
        }

        public bool CheckIfExists(Brand brand)
        {
            return _repository.GetAll().Any(x => x.Name == brand.Name);
        }

        public Brand GetOrCreate(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                _errorLogger.Error($"name cannot be null or empty");
                throw new Exception("name cannot be null");
            }

            var getBrand = GetByName(name);
            if (getBrand == null)
            {
                Create(new Brand { Name = name });
            }

            return GetByName(name);
        }
    }
}