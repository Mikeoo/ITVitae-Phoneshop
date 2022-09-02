using HtmlAgilityPack;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Support.UI;
using Phoneshop.Domain.Entities;
using Phoneshop.Domain.Interfaces;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Runtime;
using System.Threading;
using System.Threading.Tasks;

namespace Phoneshop.Business.Scrapers
{
    public class BolScraper : IScraper
    {
        public bool CanExecute(string url)
        {
            return url.StartsWith("https://www.bol.com");
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
                driver.Url = "https://www.bol.com/nl/nl/l/smartphones/4010/?sort=release_date1&rating=all";
                wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id=\"js_list_view\"]/div/div[4]")));
                var element = driver.FindElement(By.XPath("/html"));
                var innerHtml = element.GetAttribute("innerHTML");

                var doc = new HtmlDocument();
                doc.LoadHtml(innerHtml);

                var nodes = doc.DocumentNode.SelectNodes("//*[@id=\"js_items_content\"]/li");
                for (var i = 1; i < nodes.Count; i++)
                {
                    var output = doc.DocumentNode.SelectSingleNode($"//*[@id=\"js_items_content\"]/li[1]/div[2]").InnerText;
                    var check = output.Split(" ");
                    if (check.Length > 10)
                    {
                        var priceInput = doc.DocumentNode.SelectSingleNode($"//*[@id=\"js_items_content\"]/li[{i}]/div[2]/wsp-buy-block/div[1]/section/div[1]/div/span").InnerText;
                        var price = priceInput.Replace("\r\n", "").Replace("€", "").Replace("-", "").Replace(" ","");

                        var brand = doc.DocumentNode.SelectSingleNode($"//*[@id=\"js_items_content\"]/li[{i}]/div[2]/div/ul[1]/li/a").InnerText;
                        var type = doc.DocumentNode.SelectSingleNode($"//*[@id=\"js_items_content\"]/li[{i}]/div[2]/div/div[1]/a").InnerText.Replace(brand + " ", string.Empty);
                        var description = doc.DocumentNode.SelectSingleNode($"//*[@id=\"js_items_content\"]/li[{i}]/div[2]/div/div[2]").InnerText;

                        var phone = new Phone
                        {
                            Type = type,
                            Price = Convert.ToDouble(price),
                            Brand = new Brand { Name = brand},
                            Description = description
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