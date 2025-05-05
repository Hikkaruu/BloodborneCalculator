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

        public DbSet<TricksterWeapon> TricksterWeapons { get; set; }
        public DbSet<Boss> Bosses { get; set; }
        public DbSet<Scaling> Scalings { get; set; }
        public DbSet<Firearm> Firearms { get; set; }
        public DbSet<Attack> Attacks { get; set; }
        public DbSet<Origin> Origins { get; set; }
        public DbSet<EchoesPerLevel> EchoesPerLevels { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TricksterWeapon>()
                .HasOne(tw => tw.Scaling)         
                .WithOne(s => s.TricksterWeapons)  
                .HasForeignKey<TricksterWeapon>(tw => tw.ScalingId);

            modelBuilder.Entity<Firearm>()
                .HasOne(f => f.Scalings)
                .WithOne(s => s.Firearms)
                .HasForeignKey<Firearm>(f => f.ScalingId);

            modelBuilder.Entity<Attack>()
                .HasOne(a => a.TricksterWeapons)
                .WithMany(tw => tw.Attacks)
                .HasForeignKey(a => a.TricksterWeaponId);
        }
    }
}
