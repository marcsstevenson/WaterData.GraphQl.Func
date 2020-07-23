using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaterData.GraphQl.Application.PlanLimits
{
    public class PlanDetail
    {
        public string PlanName { get; set; }
        public string Status { get; set; }
        public DateTime FromDate { get; set; }
    }
}
