using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanLimits.Abstractions.Models
{
    public class Limit : ISingletonBootstrap
    {
        public string Name { get; set; }
        public List<string> SpatialUnits { get; set; }
        public string AppliesToSpatialUnits { get; set; }
        public List<Parameter> Parameters { get; set; }
    }
}
