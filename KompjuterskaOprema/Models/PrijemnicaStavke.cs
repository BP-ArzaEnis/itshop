using KompjuterskaOprema.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KompjuterskaOprema.Models
{
    public class PrijemnicaStavke:IEntity
    {
        public int Id { get; set; }
        public int Kolicina { get; set; }
        public double JedinicnaCijena { get; set; }

        public int? ArtikalId { get; set; }
        public Artikli Artikal { get; set; }

        public int? PrijemnicaId { get; set; }
        public Prijemnice Prijemnica { get; set; }
    }
}