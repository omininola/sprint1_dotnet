using Microsoft.EntityFrameworkCore;
using webapi.Model;

namespace webapi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Area> Areas { get; set; }
        public DbSet<Filial> Filiais { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Area>()
                .HasOne(a => a.Filial)
                .WithMany(f => f.Areas)
                .HasForeignKey(a => a.FilialId);
        }
    }
}
