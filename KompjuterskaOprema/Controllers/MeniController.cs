using KompjuterskaOprema.DAL;
using KompjuterskaOprema.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KompjuterskaOprema.Controllers
{
    public class MeniController : Controller
    {
        //
        // GET: /Meni/
        MojContext ctx = new MojContext();

        public class KorisnikVM
        {
            public List<Korisnici> korisnici { get; set; }
        }
        public ActionResult  Index()
        {



            var model = new KorisnikVM
            {

                korisnici = ctx.Korisnici.ToList()
            };
                
          

            return View("Index", model);
        }

    }
}
