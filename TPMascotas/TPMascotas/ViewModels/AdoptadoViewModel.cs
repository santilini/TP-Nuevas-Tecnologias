using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TPMascotas.Models;

namespace TPMascotas.ViewModels
{
    public class AdoptadoViewModel
    {
      public List<Adoptado> Adoptados { get; set; }

        public AdoptadoViewModel(List<Adoptado> adoptados)
        {
            Adoptados = adoptados;
        }
    }
}