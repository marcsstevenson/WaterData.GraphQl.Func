using System.Collections.Generic;

namespace WaterData.GraphQl.Application.PlanLimits.Models
{
    public class Parameter
    {
        public string Type { get; set; }
        public string Boundary { get; set; }
        public string Unit { get; set; }
        public List<PlanValue> values { get; set; }
    }
}
