using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TPMascotas.Models;

namespace TPMascotas.ViewModels
{
    public class AdoptadoViewModel
    {
        private const string V = "Pagina fuera de rango";

        public List<Adoptado> Adoptados { get; set; }

        public int I { get; set; }
        private int CantidadPubPagina { get; set; }
        private int pag { get; set; }

        public AdoptadoViewModel(List<Adoptado> adoptados, int max = 20, int pagina = 1)
        {
            this.Adoptados = adoptados;
            pag = pagina;
            CantidadPubPagina = max;
        }

        public List<Adoptado> paginacion()
        {
            List<Adoptado> pagina = new List<Adoptado>();
            int i = 0;
            if (pag > 1)
            {
                i += CantidadPubPagina;
            }

            while (pagina.Count < CantidadPubPagina && i <Adoptados.Count)
            {
                if (i < CantidadPubPagina * pag)
                    pagina.Add(Adoptados[i]);

                i++;
            }
            return pagina;
        }
    }
}