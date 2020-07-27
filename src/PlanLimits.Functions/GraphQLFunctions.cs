using GraphQL;
using GraphQL.NewtonsoftJson;
using GraphQL.Server.Internal;
using GraphQL.Types;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace PlanLimits.Functions
{
    public class GraphQLFunctions
    {
        private readonly IGraphQLExecuter<ISchema> _graphQLExecuter;

        public GraphQLFunctions(IGraphQLExecuter<ISchema> graphQLExecuter)
        {
            _graphQLExecuter = graphQLExecuter;
        }

        [FunctionName("graphql")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            try
            {
                ExecutionResult executionResult = await _graphQLExecuter.ExecuteAsync(req, log);

                if (executionResult.Errors != null)
                {
                    log.LogError("GraphQL execution error(s): {Errors}", executionResult.Errors);
                }

                return new GraphQLExecutionResult(executionResult, new DocumentWriter());
            }
            catch (GraphQLBadRequestException ex)
            {
                return new BadRequestObjectResult(new { message = ex.Message });
            }
        }
    }
}
