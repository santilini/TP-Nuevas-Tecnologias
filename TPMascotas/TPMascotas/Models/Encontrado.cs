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
        [Key]
        public int EncontradoID { get; set; }
        public string Localidad { get; set; }

        public Encontrado(string localidad, string foto, string raza, float tamanio, string nombre ="Animal Perdido", string tipoAnimal = "Perro") : base(foto, tipoAnimal, raza, tamanio, nombre)
        {
            this.Localidad = localidad;
        }
        public Encontrado() : base()
        {

        }
    }
}