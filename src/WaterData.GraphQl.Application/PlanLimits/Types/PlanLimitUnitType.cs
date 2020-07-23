using GraphQL.Types;
using WaterData.GraphQl.Application.PlanLimits.Models;

namespace WaterData.GraphQl.Application.PlanLimits.Types
{
    public class PlanLimitUnitType : ObjectGraphType<PlanLimitUnit>
    {
        public PlanLimitUnitType(PlanLimitUnit data)
        {
            Name = "PlanLimitUnit";
            Description = "Limits on a plan for a given area";

            Field(d => d.Id).Description("The id of the plan.");
            Field(d => d.Name, nullable: true).Description("The name of the plan.");

            //Field<ListGraphType<CharacterInterface>>(
            //    "friends",
            //    resolve: context => data.GetFriends(context.Source)
            //);
            //Field<ListGraphType<EpisodeEnum>>("appearsIn", "Which movie they appear in.");
            //Field(d => d.PrimaryFunction, nullable: true).Description("The primary function of the droid.");

            //Interface<CharacterInterface>();
        }
    }
}
