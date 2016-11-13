using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NettbankMVC.Models
{
    public class Administrator
    {
        public int id { get; set; }
        [Display(Name="Brukernavn")]
        public string brukernavn { get; set; }
        [Display(Name="Passord")]
        [DataType(DataType.Password)]
        public string passord { get; set; }

    }
}