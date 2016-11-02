using KompjuterskaOprema.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KompjuterskaOprema.Models
{
    public class Kupci:IEntity
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public string Adresa { get; set; }
        public string Email { get; set; }
        public string Telefon { get; set; }
        public string KorisnickoIme { get; set; }
        public string Lozinka { get; set; }
        public string TransakcijskiRacun { get; set; }
        public string PDVbroj { get; set; }
    }
}