using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaterData.GraphQl.Application.PlanLimits.Models
{
    public class Restiction
    {
        public Flow Flow { get; set; }
        public string RestrictionType { get; set; }
        public int Value { get; set; }
        public string Unit { get; set; }
    }
}
