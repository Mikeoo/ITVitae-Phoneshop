using System.Threading.Tasks;

namespace PhoneShop.BlazorApp.Data
{
    public interface IApiClient2
    {
        string Baseurl { get; }

        Task<T> Delete<T>(string url, int id);
        Task<T> GetRequest<T>(string url, int id = 0, string query = null);
        Task<T> PostRequest<T>(string url, T data);
    }
}