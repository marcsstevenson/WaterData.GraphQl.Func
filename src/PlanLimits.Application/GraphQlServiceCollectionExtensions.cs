using GraphQL;
using GraphQL.Server;
using GraphQL.Types;
using Microsoft.Extensions.Logging;
using PlanLimits.Abstractions;
using PlanLimits.Abstractions.Models;
using PlanLimits.CosmosDataProvider;
using PlanLimits.Application.PlanLimits;
using PlanLimits.Application.PlanLimits.Types;

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

            services.AddSingleton<PlanLimitsQuery>();
            services.AddSingleton<PlanDetail>();
            services.AddSingleton<PlanDetailType>();
            services.AddSingleton<PlanLimitUnit>();
            services.AddSingleton<PlanLimitUnitType>();
            services.AddSingleton<ISchema, PlanLimitsSchema>();

            // Azure Functions do not use `Microsoft.Extensions.DependencyInjection`, instead they use
            // DryIoc - https://github.com/dadhi/DryIoc. This leads to a different behavior if multiple
            // constructors exists so for DocumentExecuter should be called one which has no arguments.
            // See also https://bitbucket.org/dadhi/dryioc/wiki/SelectConstructorOrFactoryMethod
            services.AddSingleton<IDocumentExecuter>(sp => new DocumentExecuter());
            services.AddGraphQL();

            services.AddTransient<IPlanLimitsDataProvider, PlanLimitsCosmosDataProvider>();

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
