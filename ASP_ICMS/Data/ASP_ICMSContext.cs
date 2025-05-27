using ASP_ICMS.Models;
using Microsoft.EntityFrameworkCore;

namespace ASP_ICMS.Data
{
    public class ASP_ICMSContext : DbContext
    {
        public ASP_ICMSContext(DbContextOptions<ASP_ICMSContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<SOPMaster> SOPMaster { get; set; }
        public DbSet<ChoiceList> ChoiceList { get; set; }
    }
}
