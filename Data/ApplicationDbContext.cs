using Microsoft.EntityFrameworkCore;
using Web_Odev.Models;

namespace Web_Odev.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Kuaför> Kuaförler { get; set; }
        public DbSet<Hizmet> Hizmetler { get; set; }
        public DbSet<Calisan> Calisanlar { get; set; }
        public DbSet<Randevu> Randevular { get; set; }
        public DbSet<Kullanici> Kullanicilar { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Kuaför>().HasData(
                new Kuaför { Id = 1, Ad = "Örnek Kuaför", Adres = "Örnek Adres", CalismaSaatleri = "09:00-18:00" }
            );
        }
    }
}