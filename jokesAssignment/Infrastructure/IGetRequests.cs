using System.Net.Http;
using System.Threading.Tasks;

namespace Infrastructure
{
    public interface IGetRequests
    {
        Task<T> GetDeserialized<T>(string connectionString);
        Task<HttpResponseMessage> Get(string connectionString);
        Task<HttpResponseMessage> GetWithFilters(string connectionString, string filter);

    }
}
