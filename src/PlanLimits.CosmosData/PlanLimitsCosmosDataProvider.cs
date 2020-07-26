using PlanLimits.Abstractions;
using PlanLimits.Abstractions.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Azure.Cosmos;

namespace PlanLimits.CosmosDataProvider
{
    /// <summary>
    /// A Plan Limits data provider from Azure Cosmos DB
    /// </summary>
    public class PlanLimitsCosmosDataProvider : IPlanLimitsDataProvider
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

        /// <summary>
        /// Get a list of Plan Limit Unit results for a given set of parameters
        /// </summary>
        /// <param name="id">The Id of the plan limit unit</param>
        /// <param name="name">The Name of the plan limit unit</param>
        /// <returns>A list of Plan Limit Units</returns>
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
