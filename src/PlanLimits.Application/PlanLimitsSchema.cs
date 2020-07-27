using GraphQL.Types;
using GraphQL.Utilities;
using PlanLimits.Abstractions;
using System;

namespace PlanLimits.Application
{
    public class PlanLimitsSchema : Schema
    {
        public PlanLimitsSchema(IServiceProvider provider)
            : base(provider)
        {
            Query = provider.GetRequiredService<PlanLimitsQuery>();
            //Mutation = provider.GetRequiredService<PlanLimitsMutation>();
        }
    }
}
