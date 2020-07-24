namespace WaterData.GraphQl.Application.PlanLimits.Models
{
    public class PlanLimitUnit
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string PlanTableType { get; set; }
        public string[] Attributes { get; set; }
        public string[] SpatialUnits { get; set; }

        public PlanDetail PlanDetails { get; set; }
        //public PlanLimit PlanLimits { get; set; }
    }
}
