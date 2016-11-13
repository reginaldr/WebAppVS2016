using NettbankMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NettbankMVC.DAL
{
    public class NettbankDAL
    {


        // Kunde DB-aksess

        public List<Kunde> hentAlleKunder()
        {
            var db = new KundeContext();

            List<Kunde> liste = db.Kunder.Select(k => new Kunde()
            {
                kundeid = k.KundeID,
                fornavn = k.Fornavn,
                etternavn = k.Etternavn,
                personnummer = k.Personnummer,
                passord = k.Passord
            }).ToList();

            return liste;

        }

        public Kunde hentEnKunde(int id)
        {
            var db = new KundeContext();
            var query = db.Kunder.Find(id);
            Kunde enKunde = new Kunde()
            {
                kundeid = query.KundeID,
                fornavn = query.Fornavn,
                etternavn = query.Etternavn,
                personnummer = query.Personnummer,
                passord = query.Passord
            };
            return enKunde;
        }

        public bool settInnKunde(Kunde kunde)
        {
            var nykunde = new Kunder()
            {
                Fornavn = kunde.fornavn,
                Etternavn = kunde.etternavn,
                Personnummer = kunde.personnummer,
                Passord = kunde.passord
            };

            var db = new KundeContext();

            try
            {
                db.Kunder.Add(nykunde);
                db.SaveChanges();
                return true;
            }
            catch (Exception feil)
            {
                Console.Write(feil.Message);
                return false;
            }

        }

        public bool endreKunde(int id, Kunde innKunde)
        {
            var db = new KundeContext();
            try
            {
                Kunder endreKunde = db.Kunder.Find(id);
                endreKunde.Fornavn = innKunde.fornavn;
                endreKunde.Etternavn = innKunde.etternavn;
                endreKunde.Personnummer = innKunde.personnummer;
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool slettKunde(int id)
        {
            var db = new KundeContext();
            try
            {
                Kunder slettKunde = db.Kunder.Find(id);
                db.Kunder.Remove(slettKunde);
                db.SaveChanges();
                return true;
            }
            catch (Exception feil)
            {
                return false;
            }
        }


        // Konto DB-aksess
        public List<Konto> hentAlleKontoer()
        {
            var db = new KundeContext();

            List<Konto> liste = db.Kontoer.Select(k => new Konto()
            {
                kontoid = k.KontoID,
                kontonavn = k.Kontonavn,
                saldo = k.Saldo,
                kundeid = k.KundeID.KundeID
            }).ToList();

            return liste;
        }

        public Konto hentEnKonto(int id)
        {
            var db = new KundeContext();
            var query = db.Kontoer.Find(id);
            Konto enKonto = new Konto()
            {
                kontoid = query.KontoID,
                kontonavn = query.Kontonavn,
                saldo = query.Saldo,
                kundeid = query.KundeID.KundeID
            };
            return enKonto;
        }


        public List<Konto> hentAlleKontoerTilEnKunde(int id)
        {
            var db = new KundeContext();

            List<Konto> liste = db.Kontoer.Select(k => new Konto()
            {
                kontoid = k.KontoID,
                kontonavn = k.Kontonavn,
                saldo = k.Saldo,
                kundeid = k.KundeID.KundeID
            }).ToList();

            List<Konto> query = (from a in liste
                                 where a.kundeid == id
                                 select a).ToList();
            return query;
        }
        public bool opprettKonto(Konto innKonto, int id)
        {
            var db = new KundeContext();

            var nykonto = new Kontoer()
            {
                Kontonavn = innKonto.kontonavn,
                Saldo = innKonto.saldo,
                KundeID = db.Kunder.Find(id)
            };

            try
            {
                db.Kontoer.Add(nykonto);
                db.SaveChanges();
                return true;
            }
            catch (Exception feil)
            {
                Console.Write(feil.Message);
                return false;
            }
        }

        public bool endreKonto(int id, Konto innKonto)
        {
            var db = new KundeContext();
            try
            {
                Kontoer endreKonto = db.Kontoer.Find(id);
                endreKonto.Kontonavn = innKonto.kontonavn;
                endreKonto.Saldo = innKonto.saldo;
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool slettKonto(int id)
        {
            var db = new KundeContext();
            try
            {
                Kontoer slettKonto = db.Kontoer.Find(id);
                db.Kontoer.Remove(slettKonto);
                db.SaveChanges();
                return true;
            }
            catch (Exception feil)
            {
                return false;
            }
        }



        // Betalinger DB-aksess
        public List<Betaling> hentAlleBetalinger()
        {
            var db = new KundeContext();
            List<Betaling> liste = db.Betalinger.Select(b => new Betaling()
            {
                belop = b.Belop,
                dato = b.Dato,
                frakonto = b.Frakonto,
                tilkonto = b.Tilkonto
            }).ToList();

            return liste;
        }

        public bool leggTilBetaling(int belop, DateTime dato, int fraKonto, int tilKonto)
        {
            var db = new KundeContext();
            Betalinger nybetaling = new Betalinger();
            try
            { 
                Kontoer sender = db.Kontoer.Find(fraKonto);
                Kontoer mottaker = db.Kontoer.Find(tilKonto);
                sender.Saldo = sender.Saldo - belop;
                mottaker.Saldo = mottaker.Saldo + belop;

                nybetaling.Belop = belop;
                nybetaling.Dato = dato;
                nybetaling.Frakonto = sender.KontoID;
                nybetaling.Tilkonto = mottaker.KontoID;
                db.Betalinger.Add(nybetaling);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool leggtilBeløp(int belop, int kontoid)
        {
            var db = new KundeContext();
            try
            {
                Kontoer konto = db.Kontoer.Find(kontoid);
                konto.Saldo = konto.Saldo + belop;
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        // Dette er en testkunde for å kunne opprette databasen ved skriving.
        public void testKunde()
        {
            var kunde1 = new Kunde()
            {
                fornavn = "Reginald",
                etternavn = "Ramirez",
                personnummer = "30019212345",
                passord = "passord123"
            };

            settInnKunde(kunde1); // Setter inn testkunde

            var konto1 = new Konto()
            {
                kontonavn = "Brukskonto",
                saldo = 5000,
            };

            var konto2 = new Konto()
            {
                kontonavn = "Sparekonto",
                saldo = 3000
            };

            opprettKonto(konto1, 1); // Oppretter testkonto til testkunde
            opprettKonto(konto2, 1); // Oppretter testkonto til testkunde


            // Opprett Admin

            var admin1 = new Administratorer()
            {
                Brukernavn = "Admin",
                Passord = "passord"
            };
           
            using(var db = new KundeContext())
            {
                try
                {
                    db.Administratorer.Add(admin1);
                    db.SaveChanges();
                }
                catch(Exception feil)
                {
                    
                }
            }

        }

        // DB Innlogging Verifisering


        public int verifisering(string personnummer, string passord)
        {
            var db = new KundeContext();
            var finn = from a in db.Kunder
                       where a.Personnummer.Contains(personnummer)
                       select a.KundeID;

            if (finn == null)
            {
                return 0;
            }
            else
                return finn.FirstOrDefault();
        }

        public bool adminrettigheter(string brukernavn, string passord)
        {
            var db = new KundeContext();
            return true;
        }

    }
}