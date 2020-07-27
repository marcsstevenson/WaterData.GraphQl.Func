using Microsoft.EntityFrameworkCore;
using PlanLimits.Repository;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterData.Abstractions.Configuration;
using WaterData.Repositories.Abstractions;
using WaterData.Repositories.EfCore;

namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// A static helper class to enable the addition of Plan Limits Repositories to a given <see cref="IServiceCollection"/>
    /// via an extension to <see cref="IServiceCollection"/>
    /// </summary>
    public static class PlanLimitsRepositoryServiceCollectionExtensions
    {
        /// <summary>
        /// Add PlanLimits Repositories to the given <see cref="IServiceCollection"/> from a list of assemblies
        /// </summary>
        /// <param name="services">The service collection to add to</param>
        /// <param name="assemblies">The list of assemblies to add from</param>
        /// <returns>The same service collection to allow for fluent syntax</returns>
        /// <remarks>Adds all types that implement <see cref="IRepository<>"/> to the service collection from the given
        /// assemblies. This allows PlanLimits Repositories to be instantiated via dependency injection.</remarks>
        public static IServiceCollection UsePlanLimitsRepositories(
            [NotNull] this IServiceCollection services,
            IAppSettingProvider appSettingProvider = null,
            bool configureDatabase = true)
        {
            if (configureDatabase) // Optionally configure the database
            {
                // Resolve the appSettingProvider if needed
                if (appSettingProvider == null)
                    appSettingProvider = services.BuildServiceProvider().GetService<IAppSettingProvider>();

                // Add the PlanLimitsContext to services 
                var accountEndpoint = appSettingProvider.GetValue("WaterDataCosmosAccountEndpoint");
                if (string.IsNullOrEmpty(accountEndpoint)) throw new ApplicationException($"{nameof(accountEndpoint)} is not set");

                var accountKey = appSettingProvider.GetValue("WaterDataCosmosAccountKey");
                if (string.IsNullOrEmpty(accountKey)) throw new ApplicationException($"{nameof(accountKey)} is not set");

                var planLimitsDatabaseName = appSettingProvider.GetValue("WaterDataCosmosPlanLimitsDatabaseName");
                if (string.IsNullOrEmpty(planLimitsDatabaseName)) throw new ApplicationException($"{nameof(planLimitsDatabaseName)} is not set");

                // Use the extension method from Assembly CData.EntityFrameworkCore.Snowflake to add the Snowflake Entity Framework
                // provider to our PlanLimitsContext
                services.AddDbContext<PlanLimitsContext>(optionsBuilder => optionsBuilder
                    .UseCosmos(
                        accountEndpoint: accountEndpoint, 
                        accountKey: accountKey, 
                        databaseName: planLimitsDatabaseName));
            }

            // Add DbContext -> PlanLimitsContext so that EfRepository can access it during construction
            services.AddTransient<DbContext, PlanLimitsContext>();

            // Add our EfRepository
            services.AddTransient<IRepository, EfRepository>();

            return services;
        }
    }
}
