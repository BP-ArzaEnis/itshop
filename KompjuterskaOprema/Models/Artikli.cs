using KompjuterskaOprema.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KompjuterskaOprema.Models
{
    public class Artikli : IEntity
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public int KataloskiBroj { get; set; }
        public string Opis { get; set; }
        public double Cijena { get; set; }
    }
}