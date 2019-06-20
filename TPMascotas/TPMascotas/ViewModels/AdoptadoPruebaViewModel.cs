using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TPMascotas.Models;

namespace TPMascotas.ViewModels
{
    public class AdoptadoPruebaViewModel
    {
      public List<Adoptado> Adoptados { get; set; }

        public AdoptadoPruebaViewModel(List<Adoptado> adoptados)
        {
            Adoptados = adoptados;
        }
    }
}