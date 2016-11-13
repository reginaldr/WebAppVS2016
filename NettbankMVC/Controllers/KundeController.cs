using Nettbank.BLL;
using NettbankMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NettbankMVC.Controllers
{
    public class KundeController : Controller
    {
        // GET: Kunde

        public ActionResult Index()
        {
            Session["Admin"] = null;
            var db = new NettbankBLL();
            if (db.hentAlleKunder().Count == 0)
            {
                db.testKunde(); // Oppretter database ved å legge inn noen data
            }

            return View();
        }

        public ActionResult Registrer()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Registrer(Kunde nyKunde)
        {
            if (ModelState.IsValid)
            {
                var db = new NettbankBLL();
                bool OK = db.settInnKunde(nyKunde);
                
                if (OK)
                {
                    return RedirectToAction("Index");
                }
            }
            return View();
        }


        public ActionResult Kontoer(int id)
        {
            var db = new NettbankBLL();

            List<Konto> kontoListe = db.hentAlleKontoerTilEnKunde(id);
           
            return View(kontoListe);
        }


        // Verifisering kommer her
        [HttpPost]
        public ActionResult Verifisering(string personnummer, string passord)
        {
            ViewBag.Feilmelding = "Feil personnummer eller passord";
            var db = new NettbankBLL();

            int id = db.verifisering(personnummer, passord);
            if (id == 0)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ViewData["Id"] = id;
                return View(ViewData["Id"]);
            }
            
        }

        
    }
}