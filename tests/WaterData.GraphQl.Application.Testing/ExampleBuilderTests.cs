using Xunit;
using WaterData.GraphQl.Application.Testing.Helpers;

namespace WaterData.GraphQl.Application.Testing
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
        }
    }
}
