using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using PhoneShop.api.Models;

namespace PhoneShop.BlazorApp.Data
{
    public class MyHttpClient
    {
        private readonly HttpClient _httpClient;
        private const string BASE_URL = "https://localhost:5001";

        public MyHttpClient()
        {
            _httpClient = new HttpClient();
        }

        public async Task<string> GetRequest(string url)
        {
            string endpointPath = BASE_URL + url;

            // Make the request
            HttpResponseMessage response = await _httpClient.GetAsync(endpointPath);
            if (!response.IsSuccessStatusCode)
                throw new ArgumentException($"The path {endpointPath}          gets the following status code: " + response.StatusCode);
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> PostRequest<T>(string url, T data)
        {
            string endpointPath = BASE_URL + url;

            // Make the request
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync(endpointPath, data);
            //if (!response.IsSuccessStatusCode)
            //    throw new ArgumentException($"The path {endpointPath}          gets the following status code: " + response.StatusCode);
            return await response.Content.ReadAsStringAsync();
        }
    }
}
