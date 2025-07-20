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

        // Ajoutez vos DbSet ici, par exemple :
        // public DbSet<Bien> Biens { get; set; }
         public DbSet<Locataire> Locataires { get; set; }
    }
}
