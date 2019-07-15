using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TPMascotas.Models
{
    public class Encontrado : Publicacion
    {
        [Display(Name = "Localidad donde fue encontrado?")]
        public string Localidad { get; set; }

        public Encontrado(string localidad, string foto, string raza, string tamanio, string Desc, string genero, string nombre ="Animal Perdido", string tipoAnimal = "Perro") : base(foto, tipoAnimal, raza, tamanio, nombre, Desc, genero)
        {
            this.Localidad = localidad;
        }
        public Encontrado() : base()
        {

        }
    }
}