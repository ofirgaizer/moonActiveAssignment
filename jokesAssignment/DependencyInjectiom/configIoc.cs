using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Infrastructure;

namespace DependencyInjection
{
    public class configIoc
    {
        public IConfiguration configuration;
        public ConnectionsStrings connectionsStrings;

        public configIoc()
        {
            configuration = new ConfigurationBuilder()
                            .AddJsonFile("appsettings.json")
                            .Build();
        }
        public void injectConfig(IServiceCollection services)
        {
            services.Configure<ConnectionsStrings>(configuration.GetSection("ConnectionStrings"));
            services.Configure<HeadersModel>(configuration.GetSection("Headers"));
        }
    }
}
