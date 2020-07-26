using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanLimits.Abstractions.Models
{
    public class PlanLimits
    {
        public List<string> MeasuringPoint { get; set; }
        public string PlanSection { get; set; }
        public string PlanTable { get; set; }
        public List<Limit> Limits { get; set; }
    }
}
