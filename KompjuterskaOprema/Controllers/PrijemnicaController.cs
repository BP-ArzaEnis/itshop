using KompjuterskaOprema.DAL;
using KompjuterskaOprema.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KompjuterskaOprema.Controllers
{
    public class PrijemnicaController : Controller
    {
        //
        // GET: /Prijemnica/
        MojContext ctx = new MojContext();

        public class IndexVM
        {

            public int broj { get; set; }
            public List<Dobavljaci> dobavljaci { get; set; }
            public List<Prijemnice> prijemnice { get; set; }
   
        }

        public ActionResult Index()
        {

            var model = new IndexVM
            {
                broj= ctx.Prijemnice.Count(),
                prijemnice = ctx.Prijemnice.OrderByDescending(x => x.Id).ToList(),
                dobavljaci= ctx.Dobavljaci.ToList()


            };
            return View("Index", model);
        }

    }
}
