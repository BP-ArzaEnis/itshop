using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KompjuterskaOprema.Models;
using KompjuterskaOprema;

namespace MVC.Helper
{
    public class Autorizacija : FilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            Korisnici k = Autentifikacija.GetLogiraniKorisnik(filterContext.HttpContext);
            if (k == null)
            {
                filterContext.HttpContext.Response.Redirect("/Login");
                return;
            }
            else
            {
                GlobalHelp.prijavljeniKorisnik = k;
                filterContext.HttpContext.Response.Redirect("/Meni");
            
            }
            filterContext.HttpContext.Response.Redirect("/Meni");
        }
    }
}