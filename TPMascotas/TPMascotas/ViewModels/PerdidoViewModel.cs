using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TPMascotas.Models;

namespace TPMascotas.ViewModels
{
    public class PerdidoViewModel
    {
        private const string V = "Pagina fuera de rango";

        public List<Perdido> Perdidos { get; set; }

        public int I { get; set; }
        private int CantidadPubPagina { get; set; }
        private int pag { get; set; }

        public PerdidoViewModel(List<Perdido> perdidos, int max = 20, int pagina = 1)
        {
            this.Perdidos = perdidos;
            pag = pagina;
            CantidadPubPagina = max;
        }

        public List<Perdido> paginacion()
        {
            List<Perdido> pagina = new List<Perdido>();
            int i = 0;
            if (pag > 1)
            {
                i += CantidadPubPagina;
            }

            while (pagina.Count < CantidadPubPagina && i < Perdidos.Count)
            {
                if (i < CantidadPubPagina * pag && Perdidos[i].Visible)
                    pagina.Add(Perdidos[i]);

                i++;
            }
            return pagina;
        }
    }
}