using KompjuterskaOprema.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KompjuterskaOprema.Models
{
    public class FakturaStavke: IEntity
    {
        public int Id { get; set; }
        public DateTime Datum { get; set; }
        public int Kolicina { get; set; }
        public int Popust { get; set; }
        public double CijenaProdaje { get; set; }

        public int? FakturaId { get; set; }
        public Fakture Faktura { get; set; }

    }
}