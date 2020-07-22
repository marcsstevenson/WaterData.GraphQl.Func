using System.Net.Http;
using System.Threading.Tasks;
using AzureFunctions.Extensions.Swashbuckle;
using AzureFunctions.Extensions.Swashbuckle.Attribute;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;

namespace WaterData.GraphQl.Functions
{
    /// <summary>
    /// Provides documentation, a human readable view of the documentation and a testing harness
    /// </summary>
    public class SwaggerFunctions
    {
        /// <summary>
        /// Returns the OpenAPI documentation JSON file
        /// </summary>
        [SwaggerIgnore]
        [FunctionName("Documentation")]
        public static Task<HttpResponseMessage> Documentation(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "documentation/json")]
            HttpRequestMessage req,
            [SwashBuckleClient] ISwashBuckleClient swashBuckleClient)
        {
            return Task.FromResult(swashBuckleClient.CreateSwaggerDocumentResponse(req));
        }

        /// <summary>
        /// Provides a human readable view of the documentation and a testing harness
        /// </summary>
        [SwaggerIgnore]
        [FunctionName("SwaggerUi")]
        public static Task<HttpResponseMessage> SwaggerUi(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "swagger/ui")]
            HttpRequestMessage req,
            [SwashBuckleClient] ISwashBuckleClient swashBuckleClient)
        {
            return Task.FromResult(swashBuckleClient.CreateSwaggerUIResponse(req, "documentation/json"));
        }
    }
}
