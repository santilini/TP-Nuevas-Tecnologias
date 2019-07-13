using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TPMascotas.Models
{
    public class Publicacion
    {
        [Key]
        public int Id { get; set; }
        public string Foto { get; set; }
        public string TipoAnimal { get; set; }
        public string Raza { get; set; }
        public string Tamanio { get; set; }
        public string Nombre { get; set; }
        public string Genero { get; set; }
     //   [ForeignKey("Usuario")]
     //   public int UsuarioID { get; set; }
     //   public Usuario Usuario { get; set; }
        public string Desc { get; set; }
        public string UsuarioID { get; set; }
        public Boolean Visible { get; set; }



        public Publicacion()
        {
            Visible = true;
        }
        protected Publicacion(string foto, string tipoAnimal, string raza, string tamanio, string nombre, string desc, string Genero)
        {
            this.Foto = foto;
            this.TipoAnimal = tipoAnimal;
            this.Raza = raza;
            this.Tamanio = tamanio;
            this.Nombre = nombre;
            this.Desc = desc;
            this.Genero = Genero;
            Visible = true;
        }
    }
}