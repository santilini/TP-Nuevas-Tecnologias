using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TPMascotas.Models;

namespace TPMascotas.ViewModels
{
    public class EncontradoViewModel
    {
      public List<Encontrado> Encontrados { get; set; }
        public int i { get; set; }

        public EncontradoViewModel(List<Encontrado> encontrados)
        {
            this.Encontrados = encontrados;
        }

        public string Incrementar()
        {
            i = i++;
            return i.ToString();
        }
        public string Resetear()
        {
            this.i = 0;
            return i.ToString();
        }
    }
}