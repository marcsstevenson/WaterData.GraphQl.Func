using Microsoft.Extensions.DependencyInjection;
using PlanLimits.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterData.GraphQl.Application.Testing.Data;
using Xunit;

namespace WaterData.GraphQl.Application.Testing
{
    public class IoCTesting
    {
        [Fact]
        public void PlanLimitsInMemoryDataProviderShallResolve()
        {
            // Setup
            var services = new Startup().BuildServiceCollection();

            // Exercise
            var planLimitsDataProvider = services.BuildServiceProvider().GetService<IPlanLimitsDataProvider>();

            // Verify
            Assert.NotNull(planLimitsDataProvider);
            Assert.Equal(typeof(PlanLimitsInMemoryDataProvider), planLimitsDataProvider.GetType());
        }
    }
}
