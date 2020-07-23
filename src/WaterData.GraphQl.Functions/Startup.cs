using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

[assembly: FunctionsStartup(typeof(WaterData.GraphQl.Functions.Startup))]
namespace WaterData.GraphQl.Functions
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services
                // Use our Water Health application
                .UseGraphQlApplication();
        }
    }
}
