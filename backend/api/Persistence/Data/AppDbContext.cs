using Microsoft.EntityFrameworkCore;
using api.Models.Entities;

namespace api.Persistence.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<TricksterWeapons> TricksterWeapons { get; set; }
        public DbSet<Bosses> Bosses { get; set; }
        public DbSet<Scalings> Scalings { get; set; }
        public DbSet<Firearms> Firearms { get; set; }
        public DbSet<Attacks> Attacks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TricksterWeapons>()
                .HasOne(tw => tw.Scalings)         
                .WithOne(s => s.TricksterWeapons)  
                .HasForeignKey<TricksterWeapons>(tw => tw.ScalingId);

            modelBuilder.Entity<Firearms>()
                .HasOne(f => f.Scalings)
                .WithOne(s => s.Firearms)
                .HasForeignKey<Firearms>(f => f.ScalingId);

            modelBuilder.Entity<Attacks>()
                .HasOne(a => a.TricksterWeapons)
                .WithMany(tw => tw.Attacks)
                .HasForeignKey(a => a.TricksterWeaponId);
        }
    }
}
