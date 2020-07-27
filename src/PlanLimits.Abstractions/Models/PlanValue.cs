﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanLimits.Abstractions.Models
{
    public class PlanValue : ISingletonBootstrap
    {
        public int FromMonth { get; set; }
        public int ToMonth { get; set; }
        public int Value { get; set; }
    }
}
