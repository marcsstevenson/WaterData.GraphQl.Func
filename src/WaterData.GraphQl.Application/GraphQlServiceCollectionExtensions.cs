using Microsoft.Extensions.Logging;

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
        public static IServiceCollection UseGraphQlApplication(this IServiceCollection services)
        {
            services.AddSingleton<ILogger>(BuildLogger());

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
