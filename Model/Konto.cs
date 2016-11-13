using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NettbankMVC.Models
{
    public class Konto
    {
        // View modell

        [Display(Name = "Kontonummer")]
        public int kontoid { get; set; }
        [Display(Name = "Kontonavn")]
        public string kontonavn { get; set; }
        [Display(Name = "Saldo")]
        public int saldo { get; set; }
        [Display(Name ="Kunde ID")]
        public int kundeid { get; set; }
    }
}