using GraphQL;
using GraphQL.Server;
using GraphQL.Types;
using Microsoft.Extensions.Logging;
using PlanLimits.Abstractions;
using PlanLimits.Abstractions.Models;
using PlanLimits.Repository;
using WaterData.Abstractions.Configuration;
using WaterData.Common.Configuration;
using PlanLimits.Application.Types;
using PlanLimits.Application;
using System.Collections.Generic;
using System;
using System.Reflection;
using System.Linq;

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

            //services.AddSingleton<PlanLimitsQuery>();
            //services.AddSingleton<PlanDetail>();
            //services.AddSingleton<PlanDetailType>();
            //services.AddSingleton<PlanLimitUnit>();
            //services.AddSingleton<PlanLimitUnitType>();

            services.AddSingleton<ISchema, PlanLimitsSchema>();

            // Azure Functions do not use `Microsoft.Extensions.DependencyInjection`, instead they use
            // DryIoc - https://github.com/dadhi/DryIoc. This leads to a different behavior if multiple
            // constructors exists so for DocumentExecuter should be called one which has no arguments.
            // See also https://bitbucket.org/dadhi/dryioc/wiki/SelectConstructorOrFactoryMethod
            services.AddSingleton<IDocumentExecuter>(sp => new DocumentExecuter());
            services.AddGraphQL();

            services.AddTransient<IPlanLimitsDataProvider, PlanLimitsCosmosDataProvider>();


            services.AddSingleton<ILogger>(BuildLogger());

            // Use the provided appSettingProvider if we already have one (for unit testing purposes)
            if (appSettingProvider == null)
            {
                // Use the Functions app configuration setup provider so that we can use local.settings.json in dev and 
                // the function app configuration within Azure (the Azure environment uses this if the setting name is present)
                services.AddSingleton<IAzureConfigurationSetupProvider, FunctionAppConfigurationSetupProvider>();

                // Get our app settings from Azure Application Configuration
                services.AddSingleton<IAppSettingProvider, AzureAppConfigurationProvider>();
                appSettingProvider = services.BuildServiceProvider().GetService<IAppSettingProvider>();
            }
            else
                services.AddSingleton(appSettingProvider);

            services
                // Automagically add classes that implement ISingletonBootstrap
                // This saves having to alter this file as the models and types are expanded
                .BootstrapSingletons()
                // Include data Repositories. 
                // NOTE: This requires that IAppSettingProvider has already been added to IServiceCollection
                .UsePlanLimitsRepositories(appSettingProvider, configureDatabase);

            return services;
        }

        private static IServiceCollection BootstrapSingletons(this IServiceCollection services)
        {
            // Get all ISingletonBootstrap types from Application and Abstractions and add them to services
            // This saves having to alter this file as the models and types are expanded
            var types = GetSingletonBootstrapTypes();

            // Add each type as a Singleton
            foreach (var type in types)
            {
                services.AddSingleton(type);
            }

            return services;
        }

        /// <summary>
        /// Returns all types that implement <see cref="ISingletonBootstrap"/>
        /// </summary>
        /// <returns>A list of types</returns>
        private static List<Type> GetSingletonBootstrapTypes()
        {
            var types = new List<Type>();

            // Get all ISingletonBootstrap types from Application and Abstractions and add them to services
            types.AddRange(GetSingletonBootstrapTypes(typeof(GraphQlServiceCollectionExtensions).Assembly));
            types.AddRange(GetSingletonBootstrapTypes(typeof(ISingletonBootstrap).Assembly));

            return types;
        }

        /// <summary>
        /// Returns all types that implement <see cref="ISingletonBootstrap"/> from a given assembly
        /// </summary>
        /// <param name="assembly">A source assembly</param>
        /// <returns>A list of types</returns>
        private static List<Type> GetSingletonBootstrapTypes(Assembly assembly)
        {
            var types = new List<Type>();

            return assembly
                // Get the public (exported) types
                .GetExportedTypes().ToList()
                // Where the type implements ISingletonBootstrap
                .Where(t => t.GetInterfaces().Any(i => i.Name == nameof(ISingletonBootstrap)))
                .ToList();
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
