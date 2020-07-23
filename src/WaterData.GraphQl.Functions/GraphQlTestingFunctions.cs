using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using GraphQL;
using GraphQL.Types;
using System.Threading.Tasks;
using GraphQL.NewtonsoftJson;

namespace WaterData.GraphQl.Functions
{
    public class GraphQlTestingFunctions
    {
        /// <summary>
        /// Returns 200 if our site configuration is valid or 500 is not
        /// </summary>
        /// <returns>An action result</returns>
        [FunctionName("GraphQlTesting")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req)
        {
            var schema = Schema.For(@"
              type Query {
                hello: String
              }
            ");

            IDocumentWriter documentWriter = new DocumentWriter();

            var json = await schema.ExecuteAsync(documentWriter, _ =>
            {
                _.Query = "{ hello }";
                _.Root = new { Hello = "Hello World!" };
            });


            return new OkResult();
        }
    }
}
