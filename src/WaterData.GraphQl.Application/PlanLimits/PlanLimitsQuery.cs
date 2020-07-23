using System;
using System.Collections.Generic;
using GraphQL;
using GraphQL.Types;
using WaterData.GraphQl.Application.PlanLimits.Types;

namespace WaterData.GraphQl.Application.PlanLimits
{
    public class PlanLimitsQuery : ObjectGraphType<object>
    {
        public PlanLimitsQuery(StarWarsData data)
        {
            Name = "Query";

            //Field<CharacterInterface>("hero", resolve: context => data.GetDroidByIdAsync("3"));
            //Field<HumanType>(
            //    "human",
            //    arguments: new QueryArguments(
            //        new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "id", Description = "id of the human" }
            //    ),
            //    resolve: context => data.GetHumanByIdAsync(context.GetArgument<string>("id"))
            //);

            var client = new PlanLimitsCosmosClient();

            Func<IResolveFieldContext, string, object> getFirstPlanLimitUnitsAsync = (context, id) => client.GetFirstPlanLimitUnitsAsync();

            FieldDelegate<PlanLimitUnitType>(
                "planLimitUnit",
                //arguments: new QueryArguments(
                //    new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "id", Description = "id of the plan" }
                //),
                resolve: getFirstPlanLimitUnitsAsync
            );

            Func<IResolveFieldContext, string, object> getPlanLimitUnitsAsync = (context, id) => client.GetPlanLimitUnitsAsync();

            FieldDelegate<PlanLimitUnitType>(
                "planLimitUnits",
                //arguments: new QueryArguments(
                //    new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "id", Description = "id of the plan" }
                //),
                resolve: getPlanLimitUnitsAsync
            );
        }
    }
}
