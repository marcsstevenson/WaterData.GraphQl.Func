using PlanLimits.Abstractions;
using PlanLimits.Abstractions.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PlanLimits.Application.Testing.Helpers;

namespace PlanLimits.Application.Testing.Data
{
    /// <summary>
    /// An implementation of <see cref="IPlanLimitsDataProvider"/> using in-memory data for purposes of unit testing
    /// </summary>
    public class PlanLimitsInMemoryDataProvider : IPlanLimitsDataProvider
    {
        IList<PlanLimitUnit> _planLimitUnits;

        public PlanLimitsInMemoryDataProvider()
        {
            _planLimitUnits = new ExampleBuilder().GetExampleFixtures();
        }

        public async Task<IList<PlanLimitUnit>> GetPlanLimitUnitsAsync(string id = null, string name = null)
        {
            var result = _planLimitUnits;

            // Filter by id if needed
            if (!string.IsNullOrEmpty(id))
            {
                result = result.Where(i => i.Id == id).ToList();
            }

            // Filter by name if needed
            if (!string.IsNullOrEmpty(name))
            {
                result = result.Where(i => i.Name == name).ToList();
            }

            return await Task.FromResult(result);
        }
    }
}
