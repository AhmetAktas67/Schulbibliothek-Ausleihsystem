using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SchulbibliothekWpf.Models;

namespace SchulbibliothekWpf.Data
{
    public class BibliothekContext : DbContext
    {
        public DbSet<Buch> Buecher => Set<Buch>();
        public DbSet<Benutzer> Benutzer => Set<Benutzer>();
        public DbSet<Ausleihe> Ausleihen => Set<Ausleihe>();


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=bibliothek.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ausleihe>()
                .HasOne(a => a.Benutzer)
                .WithMany(b => b.Ausleihen)
                .HasForeignKey(a => a.BenutzerID);

            modelBuilder.Entity<Ausleihe>()
                .HasOne(a => a.Buch)
                .WithMany(b => b.Ausleihen)
                .HasForeignKey(a => a.BuchID);
        }
    }

}
