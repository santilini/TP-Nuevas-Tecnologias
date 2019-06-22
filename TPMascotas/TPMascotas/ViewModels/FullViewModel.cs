using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TPMascotas.Models;

namespace TPMascotas.ViewModels
{
    public class FullViewModel
    {
      public List<Adoptado> Adoptados { get; set; }
      public List<Encontrado> Encontrados { get; set; }
      public List<Perdido> Perdidos { get; set; }
        private int CantidadPubPagina { get; set; }
        private int Pag { get; set; }

        private const string V = "Pagina fuera de rango";




        public FullViewModel(List<Adoptado> adoptados, List<Encontrado> encontrados, List<Perdido> perdidos, int cantidad = 4, int pag = 1)
        {
            Adoptados = adoptados;
            Encontrados = encontrados;
            Perdidos = perdidos;
            CantidadPubPagina = cantidad;
            Pag = pag;
        }

        public List<Encontrado> paginacion()
        {
            List<Encontrado> pagina = new List<Encontrado>();
            if (Pag * CantidadPubPagina > Encontrados.Count)
            {
                throw new ArgumentException(V);
            }
            int i = 0;
            if (Pag > 1)
            {
                i += CantidadPubPagina;
            }

            while (pagina.Count < CantidadPubPagina && i < Encontrados.Count)
            {
                if (i < CantidadPubPagina * Pag)
                    pagina.Add(Encontrados[i]);

                i++;
            }
            return pagina;
        }
    }
}