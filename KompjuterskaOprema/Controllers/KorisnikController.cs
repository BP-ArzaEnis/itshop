﻿using MVC.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KompjuterskaOprema.Controllers
{
    public class KorisnikController : Controller
    {
        //
        // GET: /Korisnik/

        public ActionResult Index()
        {
            return View("Index");
        }
       
    }
}
