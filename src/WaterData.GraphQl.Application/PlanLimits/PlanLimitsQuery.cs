using GraphQL;
using GraphQL.Types;
using PlanLimits.Abstractions;
using WaterData.GraphQl.Application.PlanLimits.Types;

namespace WaterData.GraphQl.Application.PlanLimits
{
    public class PlanLimitsQuery : ObjectGraphType<object>
    {
        private readonly IPlanLimitsDataProvider _planLimitsDataProvider;

        public PlanLimitsQuery(IPlanLimitsDataProvider planLimitsDataProvider)
        {
            Name = "Query";

            Field<ListGraphType<PlanLimitUnitType>>(
                "planLimitUnit",
                arguments: new QueryArguments(
                    new QueryArgument<StringGraphType> { Name = "id", Description = "id of the plan" },
                    new QueryArgument<StringGraphType> { Name = "name", Description = "name of the plan" }
                ),
                resolve: context =>
                {
                    var id = context.GetArgument<string>("id");
                    return _planLimitsDataProvider.GetPlanLimitUnitsAsync(context.GetArgument<string>("id"), context.GetArgument<string>("name"));
                }
            );
            _planLimitsDataProvider = planLimitsDataProvider;
        }
    }
}
