using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TPMascotas.Models
{
    public class Publicacion
    {
        public string Foto { get; set; }
        public string TipoAnimal { get; set; }
        public string Raza { get; set; }
        public float Tamanio { get; set; }
        public string Nombre { get; set; }

        public Publicacion()
        {
            Foto = null;
            TipoAnimal = null;
            Raza = null;
            Tamanio = 0;
            Nombre = null;

        }
        protected Publicacion(string foto, string tipoAnimal, string raza, float tamanio, string nombre)
        {
            this.Foto = foto;
            this.TipoAnimal = tipoAnimal;
            this.Raza = raza;
            this.Tamanio = tamanio;
            this.Nombre = nombre;
        }
    }
}