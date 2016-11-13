using Nettbank.BLL;
using NettbankMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NettbankMVC.Controllers
{
    public class AdministratorController : Controller
    {
        // GET: Administrator
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Kontrollpanel()
        {
            Session["Admin"] = true;
            return View();
        }

        public ActionResult Kunder()
        {
            var db = new NettbankBLL();
            List<Kunde> liste = db.hentAlleKunder();
            return View(liste);
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
                    return RedirectToAction("Kunder");
                }
            }
            return View();
        }

        public ActionResult EndreKunde(int id)
        {
            var db = new NettbankBLL();
            Kunde enKunde = db.hentEnKunde(id);
            return View(enKunde);
        }

        [HttpPost]
        public ActionResult EndreKunde(int id, Kunde innKunde)
        {
            if (ModelState.IsValid)
            {
                var enKunde = new NettbankBLL();
                bool OK = enKunde.endreKunde(id, innKunde);
                if (OK)
                {
                    return RedirectToAction("Kunder");
                }
            }
            return View();
        }


        public ActionResult Detaljer(int id)
        {
            var db = new NettbankBLL();
            List<Konto> liste = db.hentAlleKontoerTilEnKunde(id);
            Kunde enKunde = db.hentEnKunde(id);
            ViewBag.KundeInfo = (enKunde.fornavn + " " + enKunde.etternavn);
            ViewBag.KundeID = id;
            if (liste == null)
                return View();
            else
                return View(liste);
        }

        public ActionResult SlettKunde(int id)
        {
            var db = new NettbankBLL();
            db.slettKunde(id);
            return RedirectToAction("Kunder");
        }

        public ActionResult Kontoer()
        {
            var db = new NettbankBLL();
            List<Konto> liste = db.hentAlleKontoer();
            return View(liste);
        }
        
        public ActionResult OpprettNyKonto()
        {
            return View();
        }

        [HttpPost]
        public ActionResult OpprettNyKonto(Konto innKonto, int id)
        {
            if (ModelState.IsValid)
            {
                var db = new NettbankBLL();
                bool OK = db.opprettKonto(innKonto, id);

                if (OK)
                {
                    return RedirectToAction("Detaljer/"+id);
                }
            }
            return View();
        }

        public ActionResult EndreKonto(int id)
        {
            var db = new NettbankBLL();
            Konto enKonto = db.hentEnKonto(id);
            return View(enKonto);
        }
        [HttpPost]
        public ActionResult EndreKonto(int id, int k, Konto innKonto)
        {
            if (ModelState.IsValid)
            {
                var enKonto = new NettbankBLL();
                bool OK = enKonto.endreKonto(id, innKonto);
                if (OK)
                {
                    return RedirectToAction("Detaljer/"+k);
                }
            }
            return View();
        }

        public ActionResult SlettKonto(int id, int k)
        {
            var db = new NettbankBLL();
            db.slettKonto(id);
            return RedirectToAction("Detaljer/"+k);
        }

        public ActionResult Betalinger()
        {
            var db = new NettbankBLL();
            List<Betaling> liste = db.hentAlleBetalinger();
            return View(liste);
        }

        public ActionResult OpprettNyTransaksjon()
        {
            return View();
        }
        [HttpPost]
        public ActionResult OpprettNyTransaksjon(int belop, int frakonto, int tilkonto)
        {
            var db = new NettbankBLL();
            bool OK = db.leggTilBetaling(belop, DateTime.Now, frakonto, tilkonto);
            if (OK)
            {
                return RedirectToAction("Betalinger");
            }
            else
                return View();
        }
    }
}