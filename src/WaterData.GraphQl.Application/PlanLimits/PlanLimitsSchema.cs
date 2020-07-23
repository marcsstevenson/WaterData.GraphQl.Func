using GraphQL.Types;
using GraphQL.Utilities;
using System;

namespace WaterData.GraphQl.Application.PlanLimits
{
    public class PlanLimitsSchema : Schema
    {
        public PlanLimitsSchema(IServiceProvider provider)
            : base(provider)
        {
            Query = provider.GetRequiredService<PlanLimitsQuery>();
            //Mutation = provider.GetRequiredService<StarWarsMutation>();
        }
    }
}
