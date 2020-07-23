using System;

namespace WaterData.GraphQl.Application.PlanLimits.Models
{
    public class PlanDetail
    {
        public string PlanName { get; set; }
        public string Status { get; set; }
        public DateTime FromDate { get; set; }
    }
}
