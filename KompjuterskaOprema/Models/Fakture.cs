using KompjuterskaOprema.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KompjuterskaOprema.Models
{
    public class Fakture: IEntity
    {
        public int Id { get; set; }
        public DateTime Datum { get; set; }

        public int? KorisnikId { get; set; }
        public Korisnici Korisnik { get; set; }

        public int? KupacId { get; set; }
        public Kupci Kupac { get; set; }
    }
}