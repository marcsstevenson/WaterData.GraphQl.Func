using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Moq;
using PlanLimits.Abstractions;
using PlanLimits.CosmosDataProvider;
using WaterData.GraphQl.Application.Testing.Data;

namespace WaterData.GraphQl.Application.Testing
{
    public class Startup
    {
        public IServiceCollection BuildServiceCollection()
        {
            IServiceCollection services = new ServiceCollection();

            services.UseGraphQlApplication();

            // Replace with PlanLimitsInMemoryDataProvider
            services.Replace(new ServiceDescriptor(typeof(IPlanLimitsDataProvider), new PlanLimitsInMemoryDataProvider()));

            //var test = 

            return services;
        }
    }
}
