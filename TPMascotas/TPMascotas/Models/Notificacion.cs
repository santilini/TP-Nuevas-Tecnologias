using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TPMascotas.Models
{
    public class Notificacion
    {
        [Key]
        public int Id { get; set; }
        public int PubID { get; set; }
        public string Tipo { get; set; }
        public string UsuarioPublicacionID { get; set; }
        public string UsuarioInteresadoID { get; set; }
        public Boolean Visible { get; set; }

        public Notificacion(int pubID, string tipo, string usuarioPublicacionID, string usuarioInteresadoID)
        {
            PubID = pubID;
            Tipo = tipo;
            UsuarioPublicacionID = usuarioPublicacionID;
            UsuarioInteresadoID = usuarioInteresadoID;
            Visible = true;
        }
        public Notificacion()
        {
            Visible = true;
        }
    }
}