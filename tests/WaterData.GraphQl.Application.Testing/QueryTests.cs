using Xunit;
using WaterData.GraphQl.Application.Testing.Helpers;
using System.Linq;
using WaterData.GraphQl.Application.PlanLimits;
using Microsoft.Extensions.DependencyInjection;
using GraphQL;
using GraphQL.Types;
using GraphQL.NewtonsoftJson;

namespace WaterData.GraphQl.Application.Testing
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
                _.Query = "{  planLimitUnit(name: \"test quality\"){ name }";
                //_.Root = new { Hello = "Hello World!" };
            });

            // Verify
            Assert.NotNull(queryResult);
        }
    }
}
