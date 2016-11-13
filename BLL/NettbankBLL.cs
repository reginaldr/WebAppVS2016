using NettbankMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NettbankMVC.DAL;

namespace Nettbank.BLL
{

    public class NettbankBLL
    {
        public List<Kunde> hentAlleKunder()
        {
            var dal = new NettbankDAL();
            return dal.hentAlleKunder();
        }

        public Kunde hentEnKunde(int id)
        {
            var dal = new NettbankDAL();
            return dal.hentEnKunde(id);

        }

        public bool settInnKunde(Kunde kunde)
        {
            var dal = new NettbankDAL();
            return dal.settInnKunde(kunde);
        }

        public bool endreKunde(int id, Kunde innKunde)
        {
            var dal = new NettbankDAL();
            return dal.endreKunde(id, innKunde);
        }

        public bool slettKunde(int id)
        {
            var dal = new NettbankDAL();
            return dal.slettKunde(id);
        }


        // Konto DB-aksess
        public List<Konto> hentAlleKontoer()
        {
            var dal = new NettbankDAL();
            return dal.hentAlleKontoer();
        }

        public List<Konto> hentAlleKontoerTilEnKunde(int id)
        {
            var dal = new NettbankDAL();
            return dal.hentAlleKontoerTilEnKunde(id);
        }

        public Konto hentEnKonto(int id)
        {
            var dal = new NettbankDAL();
            return dal.hentEnKonto(id);
        }
        public bool opprettKonto(Konto innKonto, int id)
        {
            var dal = new NettbankDAL();
            return dal.opprettKonto(innKonto, id);
        }

        public bool endreKonto(int id, Konto innKonto)
        {
            var dal = new NettbankDAL();
            return dal.endreKonto(id, innKonto);
        }

        public bool slettKonto(int id)
        {
            var dal = new NettbankDAL();
            return dal.slettKonto(id);
        }



        // Betalinger DB-aksess
        public List<Betaling> hentAlleBetalinger()
        {
            var dal = new NettbankDAL();
            return dal.hentAlleBetalinger();
        }

        public bool leggTilBetaling(int belop, DateTime dato, int fraKonto, int tilKonto)
        {
            var dal = new NettbankDAL();
            return dal.leggTilBetaling(belop, dato, fraKonto, tilKonto);
        }

        public bool leggtilBeløp(int belop, int kontoid)
        {
            var dal = new NettbankDAL();
            return dal.leggtilBeløp(belop, kontoid);
        }

        // Dette er en testkunde for å kunne opprette databasen ved skriving.
        public void testKunde()
        {
            var dal = new NettbankDAL();
            dal.testKunde();
        }

        // DB Innlogging Verifisering


        public int verifisering(string personnummer, string passord)
        {
            var dal = new NettbankDAL();
            return verifisering(personnummer, passord);
        }

        public bool adminrettigheter(string brukernavn, string passord)
        {
            var dal = new NettbankDAL();
            return dal.adminrettigheter(brukernavn, passord);
        }
    }
}
