using KompjuterskaOprema.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace KompjuterskaOprema.DAL
{
    public class MojContext : DbContext
    {
        public DbSet<Artikli> Artikli { get; set; }
        public DbSet<Dobavljaci> Dobavljaci { get; set; }
        public DbSet<FakturaStavke> FakturaStavke { get; set; }
        public DbSet<Fakture> Fakture { get; set; }
        public DbSet<Korisnici> Korisnici { get; set; }
        public DbSet<Kupci> Kupci { get; set; }
        public DbSet<PrijemnicaStavke> PrijemnicaStavke { get; set; }
        public DbSet<Prijemnice> Prijemnice { get; set; }
        public DbSet<SkladisteProizvodi> SkladisteProizvodi { get; set; }

        public MojContext()
            : base("Name=MojConnectionString")
        {

        }
    }
 
}