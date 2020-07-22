using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using WaterData.Abstractions.Configuration;
using WaterData.Repositories.Abstractions;

namespace WaterData.GraphQl.Functions
{
    public class HealthCheck
    {
        private readonly IRepository _repository;

        public HealthCheck(IRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Returns 200 if our site configuration is valid or 500 is not
        /// </summary>
        /// <returns>An action result</returns>
        [FunctionName("HealthCheck")]
        public IActionResult Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req)
        {
            if (_repository == null)
                return new StatusCodeResult(500);
            
            return new OkResult();
        }
    }
}
