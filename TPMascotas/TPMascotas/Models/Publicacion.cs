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
        [Display(Name = "Ingrese URL de foto(debe estar alojada en otro sitio)")]
        public string Foto { get; set; }
        [Display(Name = "Perro? Gato?.... Alien?")]
        public string TipoAnimal { get; set; }
        [Display(Name = "Raza?")]
        public string Raza { get; set; }
        [Display(Name = "Que tan grande es? Chico, Mediano, miniatura, gigante?")]
        public string Tamanio { get; set; }
        [Display(Name = "Indique nombre de la mascota, si posee")]
        public string Nombre { get; set; }
        [Display(Name = "Macho, Hembra?")]
        public string Genero { get; set; }
        //   [ForeignKey("Usuario")]
        //   public int UsuarioID { get; set; }
        //   public Usuario Usuario { get; set; }
        [Display(Name = "Descripcion adicional?")]
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