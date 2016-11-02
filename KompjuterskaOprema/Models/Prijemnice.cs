using KompjuterskaOprema.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KompjuterskaOprema.Models
{
    public class Prijemnice:IEntity
    {
        public int Id { get; set; }
        public DateTime Datum { get; set; }
        public double JedinicnaCijena { get; set; }

        public int? DobavljacId { get; set; }
        public Dobavljaci Dobavljac { get; set; }

        public int? KorinsikId { get; set; }
        public Korisnici Korisnik { get; set; }
    }
}