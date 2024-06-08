using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sube1entitty
{
    internal class OkulDbContext : DbContext
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
            modelBuilder.Entity<Ogrenci>().ToTable("tblOgrenciler");
            modelBuilder.Entity<Ogrenci>().Property(o => o.Ad).HasColumnType("varchar")
                .HasMaxLength(30).IsRequired();
            modelBuilder.Entity<Ogrenci>().Property(o => o.Soyad).HasColumnType("varchar")
               .HasMaxLength(40).IsRequired();
        }
       
    }
}

