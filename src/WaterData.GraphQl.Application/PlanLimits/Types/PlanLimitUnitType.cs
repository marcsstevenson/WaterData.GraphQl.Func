using GraphQL.Types;
using PlanLimits.Abstractions.Models;

namespace WaterData.GraphQl.Application.PlanLimits.Types
{
    public class PlanLimitUnitType : ObjectGraphType<PlanLimitUnit>
    {
        public PlanLimitUnitType()
        {
            Name = "PlanLimitUnit";
            Description = "Limits on a plan for a given area";

            Field(d => d.Id).Description("The id of the plan.");
            Field(d => d.Name).Description("The name of the plan.");

            //Field<ListGraphType<CharacterInterface>>(
            //    "friends",
            //    resolve: context => data.GetFriends(context.Source)
            //);
            //Field<ListGraphType<EpisodeEnum>>("appearsIn", "Which movie they appear in.");

            Field<PlanDetailType>(
                "planDetails",
                resolve: context => context.Source.PlanDetails //new PlanDetail() //data.PlanDetails
            );

            //Field<PlanDetail>(d => d.PlanDetails).Description("The plan details.");

            //Interface<CharacterInterface>();
        }
    }
}
