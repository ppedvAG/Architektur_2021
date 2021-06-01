using Microsoft.EntityFrameworkCore;
using ppedv.Cooky.Model;
using System;

namespace ppedv.Cooky.Data.EFCore
{
    public class CookyEfContext : DbContext
    {
        public DbSet<Rezept> Rezepte { get; set; }
        public DbSet<Schritte> Schritte { get; set; }
        public DbSet<Schritt> Schritt { get; set; }
        public DbSet<Zutat> Zutaten { get; set; }
        public DbSet<ZutatHinzugeben> ZutatHinzugeben { get; set; }
        public DbSet<Mixen> Mixen { get; set; }
        public DbSet<Erhitzen> Erhitzen { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Cooky;Trusted_Connection=true");
            
            optionsBuilder.UseLazyLoadingProxies(); 


            base.OnConfiguring(optionsBuilder);
        }
    }
}
