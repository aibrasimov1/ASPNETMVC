using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//neophodno uključiti kako bi se koristili DbContext i DbSet
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace OOADAspNetMVCEFAzure.Models
{
    public class OOADContext : DbContext
    {
        public OOADContext() :base("AzureConnection") //AzureConnection je naziv connection stringa u Web.config-u
        {

        }

        //dodavanjem klasa iz modela kao DbSet iste će biti mapirane u bazu podataka
        public DbSet<Student> Student { get; set; }
        public DbSet<UpisNaPredmet> UpisNaPredmet { get; set; }
        public DbSet<Predmet> Predmet { get; set; }

        //Ova funkcija se koriste da bi se ukinulo automatsko dodavanje množine u nazive
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

    }
}