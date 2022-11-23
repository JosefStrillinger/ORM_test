using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ORM_LINQ.Models.DB {
    // EFContext ist unsere Managerklasse
    //      sie ist für den Zugriff auf alle Tabellen und deren Erzeugung zuständig
    //      auch für das Eintragen, Löschen, Ändern der Datensätze ist er zuständig
    public class EFContext : DbContext{

        // DbSet  ... Datenbank-Satz (eine Zeile in der DB-Tabelle)
        // über Customers haben wir den Zugriff auf die Tabelle customers auf dem MYSQL-Server

        // der Tabellenname lautet wie das Property (hier: customers)
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Article> Articles { get; set; }    
        public DbSet<Evaluation> Evaluations { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Bill_Article> Bill_Articles { get; set; }
        public DbSet<Bill> Bill { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.ApplyConfiguration<Address>(new Address_Configuration());
            //oder:
            //modelBuilder.ApplyConfiguration(new Address_Configuration());
        }

        // hier wird der DB-Name angegeben
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            string conn = "Server=localhost;database=orm_linq;user=root;password=";
            optionsBuilder.UseMySql(conn, ServerVersion.AutoDetect(conn));
        }

    }
}
