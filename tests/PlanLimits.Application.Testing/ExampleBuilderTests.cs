using Xunit;
using PlanLimits.Application.Testing.Helpers;
using System.Linq;

namespace PlanLimits.Application.Testing
{
    public class ExampleBuilderTests
    {
        [Fact]
        public void GetExampleProvidersShallReturnAtLeastOneResult()
        {
            // Setup
            var exampleBuilder = new ExampleBuilder();

            // Exercise
            var exampleProviders = exampleBuilder.GetExampleProviders();

            // Verify
            Assert.NotNull(exampleProviders);
            Assert.NotEmpty(exampleProviders);
        }

        [Fact]
        public void GetExampleFixturesShallReturnAtLeastOneResult()
        {
            // Setup
            var exampleBuilder = new ExampleBuilder();

            // Exercise
            var exampleFixtures = exampleBuilder.GetExampleFixtures();

            // Verify
            Assert.NotNull(exampleFixtures);
            Assert.NotEmpty(exampleFixtures);

            exampleFixtures = exampleFixtures.ToList();

            Assert.True(exampleFixtures.All(i => i.PlanDetails != null));
            Assert.True(exampleFixtures.All(i => i.PlanLimits != null));
        }
    }
}
