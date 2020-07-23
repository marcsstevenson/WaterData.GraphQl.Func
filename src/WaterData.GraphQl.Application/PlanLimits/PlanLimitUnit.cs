using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaterData.GraphQl.Application.PlanLimits
{
    public class PlanLimitUnit
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public PlanDetail PlanDetails { get; set; }
    }
}
