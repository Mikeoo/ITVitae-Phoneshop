using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Phoneshop.Domain.Entities;
using Phoneshop.Domain.Interfaces;

namespace Phoneshop.Business
{
    public class ApiService : IApiService
    {
        private readonly HttpClient _httpClient;

        public ApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public IEnumerable<Phone> GetAll()
        {
            return _httpClient.GetFromJsonAsync<IEnumerable<Phone>>("https://localhost:5001/Phone/getall").Result;
        }

        
    }
}
