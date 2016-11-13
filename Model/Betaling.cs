using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NettbankMVC.Models
{
    public class Betaling
    {
        [Display(Name ="Betalings ID")]
        public int betalingid { get; set; }
        [Display(Name ="Beløp")]
        public int belop { get; set; }
        [Display(Name="Dato")]
        public DateTime dato { get; set; }
        [Display(Name ="Fra Konto")]
        public int frakonto { get; set; }
        [Display(Name ="Til Konto")]
        public int tilkonto { get; set; }
    }
}