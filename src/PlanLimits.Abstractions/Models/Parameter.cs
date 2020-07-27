using System.Collections.Generic;

namespace PlanLimits.Abstractions.Models
{
    public class Parameter : ISingletonBootstrap
    {
        public string Type { get; set; }
        public string Boundary { get; set; }
        public string Unit { get; set; }
        public List<PlanValue> values { get; set; }
    }
}
