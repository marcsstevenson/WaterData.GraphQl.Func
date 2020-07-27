namespace PlanLimits.Abstractions.Models
{
    public class PlanLimitUnit : ISingletonBootstrap
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string PlanTableType { get; set; }
        public string[] Attributes { get; set; }
        public string[] SpatialUnits { get; set; }

        public PlanDetail PlanDetails { get; set; }
        public PlanLimits PlanLimits { get; set; }
    }
}
