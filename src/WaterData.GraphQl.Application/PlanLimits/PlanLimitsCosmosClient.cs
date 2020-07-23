using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WaterData.GraphQl.Application.PlanLimits.Models;

namespace WaterData.GraphQl.Application.PlanLimits
{
    /// <summary>
    /// The purpose of this class is to provide connectivity to a Plan Limits Cosmos database
    /// </summary>
    public class PlanLimitsCosmosClient
    {
        public async Task<PlanLimitUnit> GetFirstPlanLimitUnitsAsync()
        {
            var all = await GetPlanLimitUnitsAsync();

            return all.FirstOrDefault();
        }

        public async Task<IList<PlanLimitUnit>> GetPlanLimitUnitsAsync()
        {
            CosmosClient client = new CosmosClient(
                accountEndpoint: "https://waterdata-ingest-dev-func-co.documents.azure.com:443",
                authKeyOrResourceToken: "e2GmNV3aYiqnu4x4hTOJ4BhmSGPvUoAgbfiLe2oikeVxoGNJEObnq1q89XfVIDYJYgfTK1TiD3PuUmmNgEZvRA==");

            Database database = await client.CreateDatabaseIfNotExistsAsync("TeamGraph");
            Container container = await database.CreateContainerIfNotExistsAsync(
                "PlanLimitData",
                "/id",
                400);

            var results = new List<PlanLimitUnit>();
            var sql = "select * from C";


            // Query for an item
            using (FeedIterator<PlanLimitUnit> feedIterator = container.GetItemQueryIterator<PlanLimitUnit>(sql))
            {
                while (feedIterator.HasMoreResults)
                {
                    FeedResponse<PlanLimitUnit> response = await feedIterator.ReadNextAsync();
                    foreach (var item in response)
                    {
                        results.Add(item);
                    }
                }
            }

            return results;
        }
    }
}
