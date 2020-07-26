using System;

namespace PlanLimits.Abstractions.Models
{
    public class PlanDetail
    {
        public string PlanName { get; set; }
        public string Status { get; set; }
        public DateTime FromDate { get; set; }
    }
}
