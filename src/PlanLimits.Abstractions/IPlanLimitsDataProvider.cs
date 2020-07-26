using PlanLimits.Abstractions.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlanLimits.Abstractions
{
    public interface IPlanLimitsDataProvider
    {
        /// <summary>
        /// Get a list of Plan Limit Unit results for a given set of parameters
        /// </summary>
        /// <param name="id">The Id of the plan limit unit</param>
        /// <param name="name">The Name of the plan limit unit</param>
        /// <returns>A list of Plan Limit Units</returns>
        public Task<IList<PlanLimitUnit>> GetPlanLimitUnitsAsync(string id = null, string name = null);
    }
}
