using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NLog;
using Phoneshop.Business;
using Phoneshop.Business.Repositories;
using Phoneshop.Domain.Interfaces;
using System;
using System.Windows.Forms;

namespace Phoneshop.WinForms
{
    internal static class Program
    {
        [STAThread]
        private static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            LogManager.LoadConfiguration(String.Concat("C:\\Users\\mikeo\\source\\repos\\Phoneshop.ConsoleApp\\Phoneshop.WinForms\\nlog.config"));
            var services = new ServiceCollection();

            ConfigureServices(services);

            using var serviceProvider = services.BuildServiceProvider();
            Application.Run(serviceProvider.GetRequiredService<PhoneOverview>());
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IPhoneService, PhoneService>();
            services.AddScoped<IBrandService, BrandService>();
            services.AddDbContext<DataContext>(x => x.UseSqlServer("ConnectionString"));
            services.AddScoped(typeof(IRepository<>), typeof(EFRepository<>));

            services.AddScoped<PhoneOverview>();
            services.AddScoped<AddPhone>();
            services.AddSingleton<ILoggerService, LoggerService>();
        }
    }
}