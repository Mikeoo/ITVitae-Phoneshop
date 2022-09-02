using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Phoneshop.Business;
using Phoneshop.Business.Extensions;
using Phoneshop.Business.Repositories;
using Phoneshop.Domain.Entities;
using Phoneshop.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Phoneshop.ConsoleApp
{
    internal class Program
    {
        private static Dictionary<int, Phone> _phoneList = new();
        private static IPhoneService _phoneService;
        private static bool _searching;

        private static void Main()
        {
            var services = new ServiceCollection();

            services.AddScoped<IPhoneService, PhoneService>();
            services.AddScoped<IBrandService, BrandService>();
            services.AddDbContext<DataContext>(x => x.UseSqlServer(@"Data Source=localhost,1433;Initial Catalog=Phones;User ID=sa;Password=Itvitaefase2!;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"));
            services.AddScoped<IXmlService, XmlService>();
            services.AddScoped(typeof(IRepository<>), typeof(EFRepository<>));
            services.AddSingleton<ILoggerService, LoggerService>();

            using var serviceProvider = services.BuildServiceProvider();
            _phoneService = serviceProvider.GetRequiredService<IPhoneService>();

            GetAllPhones();

            MainMenu();
        }

        private static void MainMenu()
        {
            foreach (var phone in _phoneList)
            {
                Console.WriteLine($"{phone.Key}. {phone.Value.Brand.Name} {phone.Value.Type}");
            }

            if (!_searching)
                Console.WriteLine($"{_phoneList.Count + 1}. Zoeken");
            else
                Console.WriteLine($"{_phoneList.Count + 1}. Zoeken annuleren");

            var choice = Console.ReadKey();

            try
            {
                if (choice.KeyChar - '0' == _phoneList.Count + 1)
                {
                    if (_searching)
                    {
                        _searching = false;
                        GetAllPhones();
                        Console.Clear();
                        MainMenu();
                    }
                    else
                        Search();
                }
                else
                {
                    var phone = _phoneList[choice.KeyChar - '0'];

                    ShowInfo(phone);
                }
            }
            catch (InvalidOperationException)
            {
                Console.Clear();
                Console.WriteLine("Geen goede keuze! Product niet gevonden");
                Console.WriteLine("");
                MainMenu();
            }
            catch (Exception)
            {
                Console.Clear();
                Console.WriteLine("Er ging iets gruwelijks mis....");
                Console.WriteLine("");
                MainMenu();
            }
        }

        private static void GetAllPhones()
        {
            var phones = _phoneService.GetAll().ToList();

            for (int i = 0; i < phones.Count; i++)
                _phoneList.Add(i + 1, phones[i]);
        }

        private static void ShowInfo(Phone phone)
        {
            Console.Clear();
            Console.WriteLine($"{phone.Brand} {phone.Type} {phone.Price} ({phone.PriceWithoutVat()} ex BTW)");
            Console.WriteLine("");
            Console.WriteLine(phone.Description);

            Console.ReadKey();

            Console.Clear();

            MainMenu();
        }

        private static void Search()
        {
            _searching = true;
            Console.Clear();
            Console.Write("Waar wil je op zoeken? ");
            var query = Console.ReadLine();

            var phones = _phoneService.Search(query).ToList();

            _phoneList = new Dictionary<int, Phone>();
            for (int i = 0; i < phones.Count; i++)
                _phoneList.Add(i + 1, phones[i]);

            MainMenu();
        }
    }
}