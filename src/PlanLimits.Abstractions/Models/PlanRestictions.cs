using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanLimits.Abstractions.Models
{
    public class PlanRestictions : ISingletonBootstrap
    {
        public List<string> MeasuringPoint { get; set; }
        public string Section { get; set; }
        public string PlanTable { get; set; }
        public List<Restiction> Restictions { get; set; }
    }
}
