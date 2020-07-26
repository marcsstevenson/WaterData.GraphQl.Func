using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using PlanLimits.Abstractions.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using WaterData.GraphQl.Application.Testing.Fixtures;

namespace WaterData.GraphQl.Application.Testing.Helpers
{
    public class ExampleBuilder
    {
        public IList<PlanLimitUnit> GetExampleFixtures()
        {
            // Scan the assembly for IExampleProvider
            var exampleProviders = GetExampleProviders();

            var jsonValues = exampleProviders.Select(i => i.GetJson()).ToList();

            var planLimitUnits = jsonValues.Select(i => JsonDataSerializer.Instance.Deserialize<PlanLimitUnit>(i)).ToList();

            return planLimitUnits;
        }

        public IList<IExampleProvider> GetExampleProviders()
        {
            Type[] exampleTypes = typeof(ExampleBuilder).Assembly
                // Get the public (exported) types
                .GetExportedTypes()
                // Where the type implements IExampleProvider
                .Where(t => t.GetInterfaces().Any(i => i.Name == nameof(IExampleProvider)))
                .ToArray();

            //var getGenericTypeDefinitionNames = exampleTypes.Select(i => i.GetGenericTypeDefinition().Name).ToL;

            var examples = exampleTypes.Select(i => (IExampleProvider)Activator.CreateInstance(i)).ToList();

            return examples;
        }
    }
}
