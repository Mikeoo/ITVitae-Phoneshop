using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NLog;
using Phoneshop.Business;
using Phoneshop.Business.Repositories;
using Phoneshop.Domain.Interfaces;
using System;
using System.IO;

namespace ImportTool.ConsoleApp
{
    internal class Program
    {
        private static IPhoneService _phoneService;
        private static IXmlService _xmlService;
        private static ILoggerService _loggerService;
        private static void Main(string[] args)
        {
            var services = new ServiceCollection();

            services.AddScoped<IPhoneService, PhoneService>();
            services.AddScoped<IBrandService, BrandService>();
            services.AddDbContext<DataContext>(x => x.UseSqlServer("ConnectionString"));
            services.AddScoped<IXmlService, XmlService>();
            services.AddScoped(typeof(IRepository<>), typeof(EFRepository<>));
            services.AddSingleton<ILoggerService, LoggerService>();
            LogManager.LoadConfiguration(String.Concat("C:\\Users\\mikeo\\source\\repos\\Phoneshop.ConsoleApp\\Phoneshop.WinForms\\nlog.config"));

            using ServiceProvider serviceProvider = services.BuildServiceProvider();
            _phoneService = serviceProvider.GetRequiredService<IPhoneService>();
            _xmlService = serviceProvider.GetRequiredService<IXmlService>();
            _loggerService = serviceProvider.GetRequiredService<ILoggerService>();
            if (args.Length <= 0 || !File.Exists(args[0]))
            {
                Console.Error.WriteLine("Path to file not found");
                return;
            }

            using TextReader reader = new StreamReader(args[0]);
            var phones = _xmlService.Read(reader);

            _phoneService.Create(phones);
        }
    }
}