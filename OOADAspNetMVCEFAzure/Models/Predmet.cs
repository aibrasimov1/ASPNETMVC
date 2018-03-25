using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OOADAspNetMVCEFAzure.Models
{
    public class Predmet
    {

        // dio klase u kojem definišemo atribute
        [ScaffoldColumn(false)]
        public int PredmetId { get; set; }
        [StringLength(160)]
        [Required]
        [DisplayName("Naziv predmeta")]
        public string Naziv { get; set; }
        [Range(4, 10,
         ErrorMessage = "ETCS može biti između 4 i 10")]
        public decimal ETCS { get; set; }

        //dio u kojem se definišu veze sa ostalim klasama
        public virtual ICollection<UpisNaPredmet> UpisiNaPredmet { get; set; }

    }
}