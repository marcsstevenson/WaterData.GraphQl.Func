using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Moq;
using PlanLimits.Abstractions;
using PlanLimits.Repository;
using PlanLimits.Application.Testing.Data;
using WaterData.Abstractions.Configuration;

namespace PlanLimits.Application.Testing
{
    public class Startup
    {
        public IServiceCollection BuildServiceCollection()
        {
            IServiceCollection services = new ServiceCollection();

            // Bootstrap the application but do not configure the database (which would cause a connection to Azure configuration)
            services.UseGraphQlApplication(appSettingProvider: GetAppSettingProvider(), configureDatabase: false);

            // Replace with PlanLimitsInMemoryDataProvider
            services.Replace(new ServiceDescriptor(typeof(IPlanLimitsDataProvider), new PlanLimitsInMemoryDataProvider()));

            return services;
        }


        public IAppSettingProvider GetAppSettingProvider()
        {
            var appSettingProviderMock = new Mock<IAppSettingProvider>();

            appSettingProviderMock.Setup(i => i.GetValue(It.IsAny<string>())).Returns("");

            return appSettingProviderMock.Object;
        }
    }
}
