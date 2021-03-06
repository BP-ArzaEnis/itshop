﻿using KompjuterskaOprema.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KompjuterskaOprema.Models
{
    public class Prijemnice:IEntity
    {
         public Prijemnice()
        {
        
            this.PrijemnicaStavke = new HashSet<PrijemnicaStavke>();
        }
    
        public int Id { get; set; }
        public DateTime Datum { get; set; }


        public int? DobavljacId { get; set; }
        public Dobavljaci Dobavljac { get; set; }

        public int? KorisnikId { get; set; }
        public Korisnici Korisnik { get; set; }

        public virtual ICollection<PrijemnicaStavke> PrijemnicaStavke { get; set; }
    }
}