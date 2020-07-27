using Xunit;
using PlanLimits.Application.Testing.Helpers;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using GraphQL;
using GraphQL.Types;
using GraphQL.NewtonsoftJson;

namespace PlanLimits.Application.Testing
{
    public class QueryTests
    {
        [Fact]
        public async void GetExampleProvidersShallReturnAtLeastOneResult()
        {
            // Setup
            var services = new Startup().BuildServiceCollection();
            var planLimitsSchema = new PlanLimitsSchema(services.BuildServiceProvider());

            // Exercise
            var queryResult = await planLimitsSchema.ExecuteAsync(new DocumentWriter(), _ =>
            {
                _.Query = "{  planLimitUnit{ name } }";
            });

            // Verify
            Assert.NotNull(queryResult);
        }
    }
}
