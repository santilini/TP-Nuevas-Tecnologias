using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TPMascotas.Models;

namespace TPMascotas.ViewModels
{
    public class EncontradoViewModel
    {
        private const string V = "Pagina fuera de rango";

        public List<Encontrado> Encontrados { get; set; }
      
        public int I { get; set; }
        private int CantidadPubPagina { get; set; }
        private int pag { get; set; }

        public EncontradoViewModel(List<Encontrado> encontrados, int max = 20, int pagina = 1)
        {
            this.Encontrados = encontrados;
            pag = pagina;
            CantidadPubPagina = max;
        }

       public List<Encontrado> paginacion() 
        {
            List<Encontrado> pagina = new List<Encontrado>();
         //   if (pag * CantidadPubPagina > Encontrados.Count)
        //    {
        //        throw new ArgumentException(V);
        //    }
            int i = 0;
            if (pag > 1) {
                i += CantidadPubPagina;
            }
          
            while (pagina.Count < CantidadPubPagina && i < Encontrados.Count)
            {
                if (i < CantidadPubPagina* pag)
                pagina.Add( Encontrados[i]);

                i++;
            }
            return pagina;
        }
    }
}