using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Phoneshop.Domain.Entities;
using Phoneshop.Domain.Interfaces;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Phoneshop.Business.Scrapers
{
    public class BelsimpelScraper : IScraper
    {
        public bool CanExecute(string url)
        {
            return url.StartsWith("https://www.belsimpel.nl");
        }

        public async Task<IEnumerable<Phone>> Execute(string url)
        {
            var accessToken = await GetAccesToken();
            List<Phone> phones = new List<Phone>();

            HttpClient client = new();
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls13;
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            var response = await client.GetStringAsync(url);
            var result = JsonConvert.DeserializeObject<JObject>(response);
            var JsonList = JsonConvert.DeserializeObject<List<JObject>>(result["results"].ToString());

            foreach (var p in JsonList)
            {
                Phone ph = new Phone();
                ph.Type = p["pretty_name"].ToString();
                ph.Brand = new Brand { Name = p["hardware"]["brand"].ToString() };
                ph.Description = String.Empty;
                ph.Price = double.Parse(p["hardware"]["pretty_standalone_price"].ToString().Replace(".", "").Replace(",00",""));
                phones.Add(ph);
            }
            return phones;
        }

        public async Task<string> GetAccesToken()
        {
            WebRequest request = WebRequest.Create("https://www.belsimpel.nl/API/vergelijk/Exchange?response_type=token&client_id=nl.belsimpel.public.web&scope=AllesVergelijkerSearch");
            request.ContentType = "application/json";
            using StreamReader reader = new StreamReader(request.GetResponse().GetResponseStream());
            var token = JsonConvert.DeserializeObject<JObject>(reader.ReadToEnd());
            await Task.Delay(100);
            return token["token"].ToString();
        }
    }
}
