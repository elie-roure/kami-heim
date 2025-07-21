using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using kami_heim.Models;
using Microsoft.EntityFrameworkCore;

namespace kami_heim.Data
{
    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            string appData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string dbDirectory = Path.Combine(appData, "kami_heim");
            Directory.CreateDirectory(dbDirectory);
            string dbPath = Path.Combine(dbDirectory, "kamiheim.db");
            options.UseSqlite($"Data Source={dbPath}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bien>()
                .HasKey(b => b.Id);
            modelBuilder.Entity<Locataire>()
                .HasKey(l => l.Id);
            modelBuilder.Entity<Location>()
                .HasKey(l => new { l.BienId, l.LocataireId });

            modelBuilder.Entity<Location>()
                .HasOne(l => l.Bien)
                .WithMany(b => b.Locations)
                .HasForeignKey(l => l.BienId);

            modelBuilder.Entity<Location>()
                .HasOne(l => l.Locataire)
                .WithMany(lc => lc.Locations)
                .HasForeignKey(l => l.LocataireId);
        }

        public DbSet<Locataire> Locataires { get; set; }
        public DbSet<Bien> Biens { get; set; }
        public DbSet<Location> Locations { get; set; }


    }
}
