using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;

namespace PlanLimits.Functions
{
    public class HealthCheck
    {
        public HealthCheck()
        {
        }

        /// <summary>
        /// Returns 200 if our site configuration is valid or 500 is not
        /// </summary>
        /// <returns>An action result</returns>
        [FunctionName("HealthCheck")]
        public IActionResult Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req)
        {            
            return new OkResult();
        }
    }
}
