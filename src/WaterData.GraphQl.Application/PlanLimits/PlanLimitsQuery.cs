using System;
using System.Collections.Generic;
using GraphQL;
using GraphQL.Types;
using WaterData.GraphQl.Application.PlanLimits.Types;

namespace WaterData.GraphQl.Application.PlanLimits
{
    public class PlanLimitsQuery : ObjectGraphType<object>
    {
        public PlanLimitsQuery()
        {
            Name = "Query";

            var client = new PlanLimitsCosmosClient();

            //Func<IResolveFieldContext, string, object> getFirstPlanLimitUnitsAsync = (context, id) => client.GetFirstPlanLimitUnitsAsync();

            //FieldDelegate<PlanLimitUnitType>(
            //    "planLimitUnit",
            //    //arguments: new QueryArguments(
            //    //    new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "id", Description = "id of the plan" }
            //    //),
            //    resolve: getFirstPlanLimitUnitsAsync
            //);

            //Func<IResolveFieldContext, string, object> getPlanLimitUnitsAsync = (context, id) => client.GetPlanLimitUnitsAsync();

            Field<ListGraphType<PlanLimitUnitType>>(
                "planLimitUnit",
                arguments: new QueryArguments(
                    new QueryArgument<StringGraphType> { Name = "id", Description = "id of the plan" },
                    new QueryArgument<StringGraphType> { Name = "name", Description = "name of the plan" }
                ),
                resolve: context =>
                {
                    var id = context.GetArgument<string>("id");
                    return client.GetPlanLimitUnitsAsync(context.GetArgument<string>("id"), context.GetArgument<string>("name"));
                }
            );
        }
    }
}
