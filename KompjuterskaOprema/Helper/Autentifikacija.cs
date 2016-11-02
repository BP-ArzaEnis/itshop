using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KompjuterskaOprema.DAL;
using KompjuterskaOprema.Models;

namespace MVC.Helper
{
    public class Autentifikacija
    {
          private const string LogiraniKorisnik = "logirani_korisnik";

        public static void PokreniNovuSesiju(Korisnici korisnik, HttpContextBase context, bool zapamtiPassword)
        {
            context.Session.Add(LogiraniKorisnik, korisnik);

            if (zapamtiPassword)
            {
                HttpCookie cookie = new HttpCookie("_mvc_session", korisnik != null ? korisnik.Id.ToString() : "");
                cookie.Expires = DateTime.Now.AddDays(10);
                context.Response.Cookies.Add(cookie);
            }
        }

        public static Korisnici GetLogiraniKorisnik(HttpContextBase context)
        {
            Korisnici korisnik = (Korisnici)context.Session[LogiraniKorisnik];

            if (korisnik != null)
                return korisnik;

            HttpCookie cookie = context.Request.Cookies.Get("_mvc_session");

            if (cookie == null)
                return null;

            long userId;
            try
            {
                userId = long.Parse(cookie.Value);
            }
            catch
            {
                return null;
            }



            using (MojContext db = new MojContext())
            {
                Korisnici k = db.Korisnici
         
               

                   .SingleOrDefault(x => x.Id == userId);

                PokreniNovuSesiju(k, context, true);
                return k;
            }
        }

    
    }
}