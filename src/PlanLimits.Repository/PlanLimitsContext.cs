using Microsoft.EntityFrameworkCore;

namespace PlanLimits.Repository
{
    public class PlanLimitsContext : DbContext
    {
        public PlanLimitsContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder
            //    .Entity<SnowFlakeQualityBySite>(i =>
            //    {
            //        i.HasNoKey();
            //        i.ToView("WaterQualityBySite", outboundSchema);
            //    })
            //    ;
        }
    }
}
