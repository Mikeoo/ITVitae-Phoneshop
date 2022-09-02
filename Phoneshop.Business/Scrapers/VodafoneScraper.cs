using HtmlAgilityPack;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Support.UI;
using Phoneshop.Domain.Entities;
using Phoneshop.Domain.Interfaces;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Phoneshop.Business.Scrapers
{
    public class VodafoneScraper : IScraper
    {
        public bool CanExecute(string url)
        {
            return url.StartsWith("https://www.vodafone.nl");
        }

        public async Task<IEnumerable<Phone>> Execute(string url)
        {
            var phones = new List<Phone>();

            var options = new EdgeOptions();
            options.AddArgument("headless");

            var driver = new EdgeDriver(options);
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            try
            {
                driver.Url = "https://www.vodafone.nl/telefoon/alle-telefoons?";
                //await Task.Delay(5000);
                wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id=\"vfz-app\"]/main/div[1]/section/div/div/section/div/div[2]/div[1]/a/div/h3/span")));
                var element = driver.FindElement(By.XPath("/html"));
                var innerHtml = element.GetAttribute("innerHTML");

                var doc = new HtmlDocument();
                doc.LoadHtml(innerHtml);

                var nodes = doc.DocumentNode.SelectNodes("//div[@class='vf-vodafone-product-listing__item']");
                for (var i = 1; i < nodes.Count; i++)
                {
                    var output = doc.DocumentNode.SelectSingleNode($"//*[@id=\"vfz-app\"]/main/div[1]/section/div/div/section/div/div[2]/div[{i}]/a/div/h3/span").InnerText;
                    var check = output.Split(" ");
                    if (check.Length > 10) //  todo specify 10
                    {
                        var priceInput = doc.DocumentNode.SelectSingleNode($"//*[@id=\"vfz-app\"]/main/div[1]/section/div/div/section/div/div[2]/div[{i}]/a/div/div[2]/p[2]/text()").InnerText;
                        var price = priceInput.Replace("\r\n", "").Replace("€", "").Replace(" ", "");

                        var phone = new Phone
                        {
                            Type = $"{check[17]} {check[18].Replace("\r\n", "")}",
                            Price = Convert.ToDouble(price),
                            Brand = new Brand { Name = check[16] },
                            Description = string.Empty
                        };
                        phones.Add(phone);
                    }
                }

                Thread.Sleep(5000);
                return phones;
            }
            finally
            {
                driver.Quit();
            }
        }
    }
}