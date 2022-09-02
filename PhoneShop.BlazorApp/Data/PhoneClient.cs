using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Phoneshop.Domain.Entities;

namespace PhoneShop.BlazorApp.Data
{
    public class PhoneClient : MyHttpClient, IPhoneClient
    {
        public async Task<IEnumerable<Phone>> GetAll()
            {
                string result = await GetRequest("/Phone/getall");
                return JsonConvert.DeserializeObject<IEnumerable<Phone>>(result);
            }
            public async Task<Phone> GetById(int id)
            {
                string result = await GetRequest($"/Phone/{id}");
                return JsonConvert.DeserializeObject<Phone>(result);
            }
        
    }
}
