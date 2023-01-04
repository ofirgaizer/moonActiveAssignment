using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;


namespace Infrastructure
{
    public class GetRequests:IGetRequests
    {
        private readonly Configuration _config;
        private readonly HttpClient _client;
        public GetRequests(Configuration configuration, HttpClient httpClient)
        {
            _config = configuration;
            _client = httpClient;
            addHeaders();
            
        }
        private void addHeaders()
        {
            foreach(var header in _config.HeadersModel.Headers)
            {
                _client.DefaultRequestHeaders.Add(header.Key,header.Value);
            }
        }
        
        public async Task<Tbodey> GetDeserialized<Tbodey>(string connectionString)
        { 
            try
            {
     
                using HttpResponseMessage response = await _client.GetAsync(connectionString);

                string body = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<Tbodey>(body);

    
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
                return default;
            }
            
        }
        public async Task<HttpResponseMessage> Get(string connectionString)
        {
          
            try
            {

                using HttpResponseMessage response = await _client.GetAsync(connectionString);
                return response;

            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
                return default;
            }

        }
        public async Task<HttpResponseMessage> GetWithFilters(string connectionString, string filter)
        {
            try
            {

                using HttpResponseMessage response = await _client.GetAsync($@"{connectionString}={{{filter}}}");

                return response;
          
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
                return default;
            }
        }

    }

}
