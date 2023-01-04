using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Infrastructure;

namespace DependencyInjection
{
    public class Startup
    {
        public IConfiguration configuration { get; set; }

        public Startup()
        {
            configuration = new ConfigurationBuilder()
                            .AddJsonFile("appsettings.json")
                            .Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            
         services.AddOptions();
         services.AddSingleton<configIoc>();
         services.AddSingleton<IGetRequests, GetRequests>();

        }
    }
}
