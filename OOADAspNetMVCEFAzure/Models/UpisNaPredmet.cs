using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OOADAspNetMVCEFAzure.Models
{
    public class UpisNaPredmet
    {
        // dio klase u kojem definišemo atribute
        public int UpisNaPredmetId { get; set; }
        [DisplayName ("Naziv predmeta")]
        public int PredmetId { get; set; }
        [DisplayName ("Student")]
        public int StudentId { get; set; }

        [Range(5, 100,
         ErrorMessage = "Ocjena može biti od 5 do 10")]
        public int Ocjena { get; set; }

        //dio u kojem se definišu veze sa ostalim klasama

        public virtual Predmet Predmet { get; set; }
        public virtual Student Student { get; set; }

    }
}