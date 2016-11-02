using KompjuterskaOprema.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KompjuterskaOprema.Models
{
    public class Dobavljaci: IEntity
    {
         public int Id { get; set; }
        public string Naziv {get; set;}
    }
}