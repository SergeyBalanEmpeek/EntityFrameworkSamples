using EntityFrameworkTest.Models;
using EntityFrameworkTest.Samples;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkTest
{
    public class SampleContext: DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<AuditRecord> Audit { get; set; }
        public DbSet<Team> Team { get; set; }
        public DbSet<AccountTeam> AccountTeam { get; set; }

        // Keyless
        public DbSet<Sample17Model> Sample17Model { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Sample17Model>().ToView(nameof(Sample17Model)).HasNoKey();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.;Database=EfSampleDb;user id=sa;password=1;Trusted_Connection=True;");
        }
    }
}


