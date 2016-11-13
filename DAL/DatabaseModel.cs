using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace NettbankMVC.Models
{
    public class Kunder
    {
        [Key]
        public int KundeID { get; set; }
        public string Fornavn { get; set; }
        public string Etternavn { get; set; }
        public string Personnummer { get; set; }
        public string Passord { get; set; }

    }

    public class Kontoer
    {
        [Key]
        public int KontoID { get; set; }
        public string Kontonavn { get; set; }
        public int Saldo { get; set; }
        public virtual Kunder KundeID { get; set; }
    }


    public class Betalinger
    {
        [Key]
        public int BetalingID { get; set; }
        public int Belop { get; set; }
        public DateTime Dato { get; set; }
        public int Frakonto { get; set; }
        public int Tilkonto { get; set; }
    }

    public class Administratorer
    {
        public int ID { get; set; }
        public string Brukernavn { get; set; }
        public string Passord { get; set; }
    }



    public class KundeContext : DbContext
    {
        public KundeContext() : base("name=Nettbank")
        {
            Database.CreateIfNotExists();
        }

        public DbSet<Kunder> Kunder { get; set; }
        public DbSet<Kontoer> Kontoer { get; set; }
        public DbSet<Betalinger> Betalinger { get; set; }
        public DbSet<Administratorer> Administratorer { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}