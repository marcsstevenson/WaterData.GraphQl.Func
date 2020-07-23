namespace WaterData.GraphQl.Application.PlanLimits.Models
{
    public class PlanLimitUnit
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public PlanDetail PlanDetails { get; set; }
    }
}
