using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NLog;
using Phoneshop.Business;
using Phoneshop.Business.Repositories;
using Phoneshop.Business.Scrapers;
using Phoneshop.Domain.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Phoneshop.Scraper
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            LogManager.LoadConfiguration(String.Concat("C:\\Users\\mikeo\\source\\repos\\Phoneshop.ConsoleApp\\Phoneshop.WinForms\\nlog.config"));
            var services = new ServiceCollection();
            ConfigureServices(services);

            var serviceProvider = services.BuildServiceProvider();
            var scraperService = serviceProvider.GetService<IScraperService>();
            var scrapers = serviceProvider.GetServices<IScraper>();


            var phones = await scraperService.GetPhones(scrapers);
            await scraperService.AddPhones(phones);


        }

        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IPhoneService, PhoneService>();
            services.AddScoped<IBrandService, BrandService>();
            services.AddDbContext<DataContext>(x => x.UseSqlServer("ConnectionString"));
            services.AddScoped(typeof(IRepository<>), typeof(EFRepository<>));
            services.AddSingleton<ILoggerService, LoggerService>();

            services.AddScoped<IScraperService, ScraperService>();
            services.AddScoped<IScraper, VodafoneScraper>();
            services.AddScoped<IScraper, BelsimpelScraper>();
            services.AddScoped<IScraper, BolScraper>();
        }
    }
}

//foreach (var phone in phoneService.GetAll().Where(x=>x.Description == null))
//{
//    phone.Description = String.Empty;
//}

// await phoneService.SaveChanges();