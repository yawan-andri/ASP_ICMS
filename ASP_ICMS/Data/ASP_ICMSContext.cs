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
			// SOPMaster
			modelBuilder.Entity<SOPMaster>()
					 .HasKey(s => s.Id);

			modelBuilder.Entity<SOPMaster>()
				.HasOne(s => s.Division)
				.WithMany(c => c.SOPMasters)
				.HasForeignKey(s => s.DivisionId)
				.OnDelete(DeleteBehavior.Restrict);

			// ChoiceList
			modelBuilder.Entity<ChoiceList>()
				.HasKey(c => c.Id);

			// SOPMasterAuditType
			modelBuilder.Entity<SOPMasterAuditType>()
				.HasKey(a => a.Id);

			modelBuilder.Entity<SOPMasterAuditType>()
				.HasOne(a => a.SOPMaster)
				.WithMany(s => s.AuditTypes)
				.HasForeignKey(a => a.SOPMasterId)
				.OnDelete(DeleteBehavior.Cascade);

			modelBuilder.Entity<SOPMasterAuditType>()
				.HasOne(a => a.SOPAuditType)
				.WithMany(c => c.SOPAuditTypes)
				.HasForeignKey(a => a.SOPAuditTypeId)
				.OnDelete(DeleteBehavior.Restrict);

			// SOPMasterType
			modelBuilder.Entity<SOPMasterType>()
				.HasKey(t => t.Id);

			modelBuilder.Entity<SOPMasterType>()
				.HasOne(t => t.SOPMaster)
				.WithMany(s => s.SOPTypes)
				.HasForeignKey(t => t.SOPMasterId)
				.OnDelete(DeleteBehavior.Cascade);

			modelBuilder.Entity<SOPMasterType>()
				.HasOne(t => t.SOPType)
				.WithMany(c => c.SOPTypes)
				.HasForeignKey(t => t.SOPTypeId)
				.OnDelete(DeleteBehavior.Restrict);

			base.OnModelCreating(modelBuilder);
        }

        public DbSet<SOPMaster> SOPMaster { get; set; }
        public DbSet<ChoiceList> ChoiceList { get; set; }
        public DbSet<SOPMasterType> SOPMasterType { get; set; }
        public DbSet<SOPMasterAuditType> SOPMasterAuditType { get; set; }
    }
}
