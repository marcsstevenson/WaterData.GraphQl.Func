using Microsoft.Extensions.DependencyInjection;
using Moq;
using System;
using WaterData.Abstractions.Configuration;

namespace WaterData.GraphQl.Application.Testing
{
    public class Startup
    {
        public IServiceCollection BuildServiceCollection()
        {
            IServiceCollection services = new ServiceCollection();

            services
                // Use our application with a mocked out IAppSettingProvider
                .UseGraphQlApplication(GetAppSettingProvider(), configureDatabase: false);

            return services;
        }

        public IAppSettingProvider GetAppSettingProvider()
        {
            var appSettingProviderMock = new Mock<IAppSettingProvider>();

            appSettingProviderMock.Setup(i => i.GetValue(It.IsAny<string>()))
                // Note, this connection string is not real but it does follow Snowflake's format so that EF provider can be bootstrapped
                .Returns("account=r;url=https://r.australia-east.azure.snowflakecomputing.com;user=user;password=123123!;database=WATERDATAREPO;warehouse=COMPUTE_WH;schema=plm");

            return appSettingProviderMock.Object;
        }
    }
}
