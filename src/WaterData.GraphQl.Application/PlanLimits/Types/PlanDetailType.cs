using GraphQL.Types;
using WaterData.GraphQl.Application.PlanLimits.Models;

namespace WaterData.GraphQl.Application.PlanLimits.Types
{
    public class PlanDetailType : ObjectGraphType<PlanDetail>
    {
        public PlanDetailType()
        {
            Name = "PlanDetail";
            Description = "The details of a plan";

            Field(d => d.PlanName).Description("The name of the plan");
            Field(d => d.Status).Description("The plan status");
            Field(d => d.FromDate).Description("The date that the plan starts");
        }
    }
}
