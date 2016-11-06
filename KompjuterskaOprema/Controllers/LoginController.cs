using KompjuterskaOprema.DAL;
using KompjuterskaOprema.Helper;
using KompjuterskaOprema.Models;
using MVC.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KompjuterskaOprema.Controllers
{
    public class LoginController : Controller
    {
        private MojContext ctx = new MojContext();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Provjera(string username, string password, string zapamti)
        {
            Korisnici k = ctx.Korisnici
            
                .SingleOrDefault(x => x.KorisnickoIme == username);
            if (k == null)
            {
                return Redirect("/Meni");
            }

            else  if ((WebHelper.GenerateHash(password, k.LozinkaSalt)) == k.LozinkaHash && username == k.KorisnickoIme)
            {
                Autentifikacija.PokreniNovuSesiju(k, HttpContext, (zapamti == "on"));
                Korisnici korisnik = Autentifikacija.GetLogiraniKorisnik(HttpContext);
                GlobalHelp.prijavljeniKorisnik = Autentifikacija.GetLogiraniKorisnik(HttpContext);

               return RedirectToAction("Index", "Korisnik", new { });
            }
            else
            return Redirect("/Meni");
        }

        public ActionResult Logout()

        {
            GlobalHelp.AktivnePrijemnice = null;
            GlobalHelp.prijavljeniKorisnik = null;
            Autentifikacija.PokreniNovuSesiju(null, HttpContext, true);
            return Redirect("/Meni");
        }
    }
}
