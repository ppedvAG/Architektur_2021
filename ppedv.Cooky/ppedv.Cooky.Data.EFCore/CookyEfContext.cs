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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ZutatHinzugeben>().ToTable("ZutatHinzugeben");
            modelBuilder.Entity<Mixen>().ToTable("Mixen");
            modelBuilder.Entity<Erhitzen>().ToTable("Erhitzen");

            modelBuilder.Entity<Rezept>().Property(x => x.Name)
                                         .IsRequired()
                                         .HasMaxLength(59)
                                         .HasColumnName("Rezeptname");


            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            foreach (var entry in this.ChangeTracker.Entries())
            {
                if (entry.Entity is Entity e)
                {
                    if (entry.State == EntityState.Added)
                    {
                        e.Created = DateTime.Now;
                        e.Modified = DateTime.Now;
                    }
                    else if (entry.State == EntityState.Modified)
                        e.Modified = DateTime.Now;

                }
            }

            return base.SaveChanges();
        }
    }
}
