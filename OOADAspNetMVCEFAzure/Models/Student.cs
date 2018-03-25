using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OOADAspNetMVCEFAzure.Models
{
    public class Student
    {
        // dio klase u kojem definišemo atribute
        [ScaffoldColumn(false)]
        public int ID { get; set; }
        
        [Required]
        public string Ime { get; set; }
        [Required]
        public string Prezime { get; set; }

        public string ImePrezime { get { return string.Format("{0} {1}", Ime, Prezime); } }

        //dio u kojem se definišu veze sa ostalim klasama

        public virtual ICollection<UpisNaPredmet> UpisiNaPredmet { get; set; }
    }
}