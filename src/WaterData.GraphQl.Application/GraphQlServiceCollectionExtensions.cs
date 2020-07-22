using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using WaterData.Abstractions.Configuration;
using WaterData.Common.Configuration;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class GraphQlServiceCollectionExtensions
    {
        /// <summary>
        /// Add required services for Water Health to a given service collection
        /// </summary>
        /// <param name="services">A service collection</param>
        /// <param name="appSettingProvider">A application settings provider</param>
        /// <param name="configureDatabase">If we are to configure the database (for unit testing purposes)</param>
        /// <returns>The same service collection for fluent API</returns>
        public static IServiceCollection UseGraphQlApplication(this IServiceCollection services,
            IAppSettingProvider appSettingProvider = null,
            bool configureDatabase = true)
        {
            services.AddSingleton<ILogger>(BuildLogger());

            // Use the provided appSettingProvider if we already have one (for unit testing purposes)
            if (appSettingProvider == null)
            {
                // Use the Functions app configuration setup provider so that we can use local.settings.json in dev and 
                // the function app configuration within Azure (the Azure environment uses this if the setting name is present)
                services.AddSingleton<IAzureConfigurationSetupProvider, FunctionAppConfigurationSetupProvider>();

                // Get our app settings from Azure Application Configuration
                services.AddSingleton<IAppSettingProvider, AzureAppConfigurationProvider>();
            }
            else
                services.AddSingleton(appSettingProvider);

            // Wire up our request handlers
            services.UseRequestHandling(typeof(GraphQlServiceCollectionExtensions).Assembly);

            return services;
        }

        private static ILogger BuildLogger()
        {
            var loggerFactory = LoggerFactory.Create(builder =>
            {
                // Providers for Azure Functions?
            });
            ILogger logger = loggerFactory.CreateLogger("GraphQl");

            return logger;
        }
    }
}
