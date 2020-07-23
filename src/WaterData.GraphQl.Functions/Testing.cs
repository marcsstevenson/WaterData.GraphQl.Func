using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using System.Threading.Tasks;
using WaterData.GraphQl.Application.PlanLimits;
using Microsoft.Extensions.Logging;

namespace WaterData.GraphQl.Functions
{
    public class Testing
    {
        /// <summary>
        /// Returns 200 if our site configuration is valid or 500 is not
        /// </summary>
        /// <returns>An action result</returns>
        [FunctionName("Testing")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req,
            ILogger logger)
        {
            var client = new PlanLimitsCosmosClient();

            var results = await client.GetPlanLimitUnitsAsync();

            return new OkObjectResult(new { count = results.Count, results });
        }
    }
}
