using Microsoft.Azure.Cosmos;
using System.Collections.Generic;
using System.Threading.Tasks;
using WaterData.GraphQl.Application.PlanLimits.Models;

namespace WaterData.GraphQl.Application.PlanLimits
{
    /// <summary>
    /// The purpose of this class is to provide connectivity to a Plan Limits Cosmos database
    /// </summary>
    public class PlanLimitsCosmosClient
    {
        private async Task<Container> Initialise()
        {
            CosmosClient client = new CosmosClient(
                accountEndpoint: "https://waterdata-ingest-dev-func-co.documents.azure.com:443",
                authKeyOrResourceToken: "e2GmNV3aYiqnu4x4hTOJ4BhmSGPvUoAgbfiLe2oikeVxoGNJEObnq1q89XfVIDYJYgfTK1TiD3PuUmmNgEZvRA==");

            Database database = await client.CreateDatabaseIfNotExistsAsync("TeamGraph");
            return await database.CreateContainerIfNotExistsAsync(
                "PlanLimitData",
                "/id",
                400);
        }

        public async Task<IList<PlanLimitUnit>> GetPlanLimitUnitsAsync(string id = null, string name = null)
        {
            Container container = await Initialise();

            var results = new List<PlanLimitUnit>();

            var sql = "select * from C where 1 = 1";

            // Filter by Id if needed
            if (!string.IsNullOrEmpty(id))
            {
                sql += $" and C.id = \"{id}\"";
            }

            if (!string.IsNullOrEmpty(name))
            {
                sql += $" and C.name = \"{name}\"";
            }

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
