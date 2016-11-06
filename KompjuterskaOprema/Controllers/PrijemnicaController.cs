using KompjuterskaOprema.DAL;
using KompjuterskaOprema.Models;
using MVC.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
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
        public class DetaljiVM
        {

            public List<Artikli> artikli { get; set; }
            public List<PrijemnicaStavke> prijemnicaStavke { get; set; }

        }
        public ActionResult Detalji(int Id)
        {
      
            var model = new DetaljiVM
            {
               prijemnicaStavke= ctx.PrijemnicaStavke.Where(x=>x.PrijemnicaId== Id).ToList(),
                artikli= ctx.Artikli.ToList()

            };

            return View(model);
        }

        public class StavkeVM
        {

            public List<Artikli> artikli { get; set; }
            public List<PrijemnicaStavke> prijemnicaStavke { get; set; }

        }
        public ActionResult Stavke(int Id)
        {

            var model = new StavkeVM
            {
                prijemnicaStavke =  GlobalHelp.AktivnePrijemnice.PrijemnicaStavke.Where(x=> x.PrijemnicaId==Id).ToList(),
              
                artikli = ctx.Artikli.ToList()

            };

            return View(model);
        }



        public class UrediVM
        {
            public int? Id { get; set; }
          
   
            
            public int? DobavljacId { get; set; }
            public List<SelectListItem> DobavljacStavke { get; set; }

            public int? ArtikalId { get; set; }
            public List<SelectListItem> ArtikalStavke { get; set; }

            public List<SelectListItem> KolicinaStavke { get; set; }
            public int kolicina { get; set; }
        }

        public ActionResult AddToKorpa1(int ArtikalId, int kolicina, int dobavljacId)
        {
            int ID = ctx.Artikli.Where(x => x.Id == ArtikalId).FirstOrDefault().Id;
            Artikli a = ctx.Artikli.Find(ID);
            GlobalHelp.AddToKorpa(a, kolicina, dobavljacId);
           
            

                return RedirectToAction("Dodaj", "Prijemnica");
            
        }




        private List<SelectListItem> UcitajDobavljace()
        {
            var dobavljaci = new List<SelectListItem>();
            dobavljaci.Add(new SelectListItem { Value = null, Text = "(Odaberi dobavljaca)" });

            dobavljaci.AddRange(ctx.Dobavljaci.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Naziv
            }).ToList());
            return dobavljaci;
        }

        private List<SelectListItem> UcitajKolicine()
        {
            var k = new List<SelectListItem>();
            k.Add(new SelectListItem { Value = null, Text = "(Odaberi kolicinu)" });

            for (var i = 1; i < 10; i++)
                k.Add(new SelectListItem { Text = i.ToString(), Value = i.ToString() });
            ViewBag.list = k;
            return k;
        }
        private List<SelectListItem> UcitajArtikle()
        {
            var artikli = new List<SelectListItem>();
            artikli.Add(new SelectListItem { Value = null, Text = "(Odaberi artikal)" });

            artikli.AddRange(ctx.Artikli.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Naziv
            }).ToList());
            return artikli;
        }
        public ActionResult Uredi(int Id)
        {
            var x = ctx.Prijemnice.Find(Id);
            var model = new UrediVM
            {

                Id = x.Id,
               DobavljacId=x.DobavljacId.Value,
          
                DobavljacStavke=UcitajDobavljace(),
                 ArtikalStavke= UcitajArtikle(),
                  KolicinaStavke=UcitajKolicine()
          

            };
            return View("PrijemnicaDodaj", model);

        }
        public ActionResult Dodaj()
        {
            UrediVM model = new UrediVM();
            model.DobavljacStavke = UcitajDobavljace();
            model.ArtikalStavke = UcitajArtikle();
            model.KolicinaStavke = UcitajKolicine();

            return View("PrijemnicaDodaj", model);
        }


        public ActionResult Snimi(UrediVM model)
        {

            if (!ModelState.IsValid)
            {
                model.DobavljacStavke = UcitajDobavljace();

                return View("PrijemnicaDodaj", model);

            }
            Prijemnice x;
            if (model.Id == 0)
            {
                x = new Prijemnice();


                //x.Student = ctx.Studenti.Where(y => y.Id == model.StudentId).FirstOrDefault();
                //x.Soba = ctx.Sobe.Where(y => y.Id == model.SobaId).FirstOrDefault();
                //x.SkolskaGodina = ctx.SkolskeGodine.Where(y => y.Id == model.SkolskaGodinaId).FirstOrDefault();


                ctx.Prijemnice.Add(x);
            }
            else
            {
                x = ctx.Prijemnice.Where(o => o.Id == model.Id).FirstOrDefault();
            }

            x.DobavljacId = model.DobavljacId;
            x.Datum = DateTime.Now;
           
           


            ctx.SaveChanges();

            return RedirectToAction("PrijemnicaDodaj");
        }


        public ActionResult Zakljuci()
        {

            Prijemnice prijemnica = new Prijemnice();



            prijemnica.DobavljacId = GlobalHelp.AktivnePrijemnice.DobavljacId;
            prijemnica.Datum = GlobalHelp.AktivnePrijemnice.Datum;
            prijemnica.KorisnikId = GlobalHelp.prijavljeniKorisnik.Id;

           

            foreach (var item in GlobalHelp.AktivnePrijemnice.PrijemnicaStavke)
            {
                PrijemnicaStavke stavka = new PrijemnicaStavke();
                ctx.PrijemnicaStavke.Add(stavka);
                stavka.ArtikalId = item.ArtikalId;
                stavka.PrijemnicaId = item.PrijemnicaId;
                stavka.Kolicina = item.Kolicina;

            }
            ctx.Prijemnice.Add(prijemnica);
            GlobalHelp.AktivnePrijemnice = null;
            ctx.SaveChanges();
            return RedirectToAction("Index", "Prijemnica");
        }




    }

}
