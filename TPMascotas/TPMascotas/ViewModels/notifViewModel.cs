using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TPMascotas.ViewModels
{
    public class NotifViewModel
    {
        public string NombreInteresado { get; set; }
        public string Mail { get; set; }
        public string Telefono { get; set; }
        public string Publicacion { get; set; }

        public NotifViewModel(string nombreInteresado, string mail, string telefono)
        {
            NombreInteresado = nombreInteresado;
            Mail = mail;
            Telefono = telefono;
        }
        
    }
}