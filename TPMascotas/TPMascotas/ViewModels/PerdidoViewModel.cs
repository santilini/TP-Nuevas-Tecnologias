using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TPMascotas.Models;

namespace TPMascotas.ViewModels
{
    public class PerdidoViewModel
    {
      public List<Perdido> Perdidos { get; set; }

        public PerdidoViewModel(List<Perdido> Perdidos)
        {
            this.Perdidos = Perdidos;
        }
    }
}