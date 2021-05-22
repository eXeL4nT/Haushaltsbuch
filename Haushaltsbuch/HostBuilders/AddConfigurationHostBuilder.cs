using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace Haushaltsbuch.HostBuilders
{
    public static class AddConfigurationHostBuilder
    {
        public static IHostBuilder AddConfiguration(this IHostBuilder host)
        {
            host.ConfigureAppConfiguration(c =>
            {
                c.AddJsonFile("appsettings.json");
                c.AddEnvironmentVariables();
            });

            return host;
        }
    }
}
