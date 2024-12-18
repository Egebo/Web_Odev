using Microsoft.EntityFrameworkCore;
using Web_Odev.Models;

namespace Web_Odev.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Kuafor> Kuaforler { get; set; }
        public DbSet<Calisan> Calisanlar { get; set; }
        public DbSet<Randevu> Randevular { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Randevu>()
                .Property(r => r.Ucret)
                .HasPrecision(18, 2); // Precision: 18 basamak, Scale: 2 basamak
        }
    }
}
