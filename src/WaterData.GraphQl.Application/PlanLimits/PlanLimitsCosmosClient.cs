using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace WaterData.GraphQl.Application.PlanLimits
{
    /// <summary>
    /// The purpose of this class is to provide connectivity to a Plan Limits Cosmos database
    /// </summary>
    public class PlanLimitsCosmosClient
    {
        public async Task<int> Go(ILogger logger)
        {
            CosmosClient client = new CosmosClient(
                accountEndpoint: "",
                authKeyOrResourceToken: "");

            Database database = await client.CreateDatabaseIfNotExistsAsync("TeamGraph");
            Container container = await database.CreateContainerIfNotExistsAsync(
                "PlanLimitData",
                "/id",
                400);

            var resultCount = 0;
            var sql = "select * from C";


            // Query for an item
            using (FeedIterator<dynamic> feedIterator = container.GetItemQueryIterator<dynamic>(sql))
            {
                while (feedIterator.HasMoreResults)
                {
                    FeedResponse<dynamic> response = await feedIterator.ReadNextAsync();
                    foreach (var item in response)
                    {
                        resultCount++;
                        string str = item.ToString();
                        logger.LogDebug(str);
                    }
                }
            }

            return resultCount;
        }
    }
}
