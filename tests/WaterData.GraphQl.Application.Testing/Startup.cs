using Microsoft.Extensions.DependencyInjection;
using Moq;

namespace WaterData.GraphQl.Application.Testing
{
    public class Startup
    {
        public IServiceCollection BuildServiceCollection()
        {
            IServiceCollection services = new ServiceCollection();

            services.UseGraphQlApplication();

            return services;
        }
    }
}
