using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NettbankMVC.Models
{
    public class Kunde
    {
        // View modell
        [Display(Name ="Kunde #")]
        public int kundeid { get; set; }
        [Display(Name = "Fornavn")]
        public string fornavn { get; set; }
        [Display(Name = "Etternavn")]
        public string etternavn { get; set; }
        [Display(Name = "Personnummer")]
        public string personnummer { get; set; }
        [Display(Name = "Passord")]
        [DataType(DataType.Password)]
        public string passord { get; set; }
    }
}