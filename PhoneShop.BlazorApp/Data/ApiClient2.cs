using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace PhoneShop.BlazorApp.Data
{
    public class ApiClient2 : IApiClient2
    {

        public ApiClient2(string baseurl)
        {
            Baseurl = baseurl;
        }

        public string Baseurl { get; }

        public async Task<T> GetRequest<T>(string url, int id = default, string query = default)
        {
            string endpointPath = Baseurl + url;
            using var client = new HttpClient();
            var response = new HttpResponseMessage();
            if (!string.IsNullOrEmpty(query))
            {
                response = await client.GetAsync(endpointPath + query);

            }
            else if (id > 0)
            {
                response = await client.GetAsync(endpointPath + id);
            }
            else
            {
                response = await client.GetAsync(endpointPath);
            }

            if (!response.IsSuccessStatusCode)
                throw new ArgumentException($"The path {endpointPath}          gets the following status code: " + response.StatusCode);
            return JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync());
        }

        public async Task<T> PostRequest<T>(string url, T data)
        {
            string endpointPath = Baseurl + url;
            using var client = new HttpClient();

            HttpResponseMessage response = await client.PostAsJsonAsync(endpointPath, data);

            return JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync());
        }

        public async Task<T> Delete<T>(string url, int id)
        {
            string endpointPath = Baseurl + url;
            using var client = new HttpClient();

            HttpResponseMessage response = await client.DeleteAsync(endpointPath + id);

            return JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync());
        }
    }
}
