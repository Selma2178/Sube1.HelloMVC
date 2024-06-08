using Microsoft.EntityFrameworkCore;
using Sube1.HelloMVC.Models;

namespace Sube1.HelloMVC
{
    public class OkulDbcontext : DbContext
    {
        public DbSet<Ogrenci> Ogrenciler { get; set; }
        public DbSet<Ders> Dersler { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=localhost;Initial Catalog=OkulDbEf;Integrated Security=true; TrustServerCertificate=true");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Ogrenci>().ToTable("tblOgrenciler2");
            modelBuilder.Entity<Ogrenci>().Property(o => o.Ad).HasColumnType("varchar").HasMaxLength(30).IsRequired();
            modelBuilder.Entity<Ogrenci>().Property(o => o.Soyad).HasColumnType("varchar").HasMaxLength(30).IsRequired();

            modelBuilder.Entity<Ders>().ToTable("tblDersler");
            modelBuilder.Entity<Ders>().Property(o => o.Dersad).HasColumnType("varchar").HasMaxLength(30).IsRequired();
            modelBuilder.Entity<Ders>().Property(o => o.Kredi).HasColumnType("tinyint").IsRequired();
            modelBuilder.Entity<Ders>().Property(o => o.Ogrenciid).HasColumnType("int").IsRequired();

        }
    }
}
