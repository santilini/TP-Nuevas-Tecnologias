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

        public List<Encontrado> PaginacionE()
        {
            List<Encontrado> pagina = new List<Encontrado>();
        //    if (Pag * CantidadPubPagina > Encontrados.Count)
        //    {
        //        throw new ArgumentException(V);
        //   }
            int i = 0;
            if (Pag > 1)
            {
                i += CantidadPubPagina;
            }

            while (pagina.Count < CantidadPubPagina && i < Encontrados.Count)
            {
                if (i < CantidadPubPagina * Pag && Encontrados[i].Visible)
                    pagina.Add(Encontrados[i]);

                i++;
            }
            return pagina;
        }
        public List<Adoptado> PaginacionA()
        {
            List<Adoptado> pagina = new List<Adoptado>();
            //    if (Pag * CantidadPubPagina > Encontrados.Count)
            //    {
            //        throw new ArgumentException(V);
            //   }
            int i = 0;
            if (Pag > 1)
            {
                i += CantidadPubPagina;
            }

            while (pagina.Count < CantidadPubPagina && i < Adoptados.Count)
            {
                if (i < CantidadPubPagina * Pag && Adoptados[i].Visible)
                    pagina.Add(Adoptados[i]);

                i++;
            }
            return pagina;
        }
        public List<Perdido> PaginacionP()
        {
            List<Perdido> pagina = new List<Perdido>();
            //    if (Pag * CantidadPubPagina > Encontrados.Count)
            //    {
            //        throw new ArgumentException(V);
            //   }
            int i = 0;
            if (Pag > 1)
            {
                i += CantidadPubPagina;
            }

            while (pagina.Count < CantidadPubPagina && i < Perdidos.Count)
            {
                if (i < CantidadPubPagina * Pag && Perdidos[i].Visible)
                    pagina.Add(Perdidos[i]);

                i++;
            }
            return pagina;
        }
    }
}