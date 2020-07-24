﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaterData.GraphQl.Application.PlanLimits.Models
{
    public class Limit
    {
        public string Name { get; set; }
        public List<string> SpatialUnits { get; set; }
        public string AppliesToSpatialUnits { get; set; }
        public List<Parameter> Parameters { get; set; }
    }
}
