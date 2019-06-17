using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TPMascotas.Models
{
    public class Publicacion
    {
        public string foto { get; set; }
        public string tipoAnimal { get; set; }
        public string raza { get; set; }
        public float tamanio { get; set; }
        public string nombre { get; set; }

        public Publicacion()
        {
            foto = null;
            tipoAnimal = null;
            raza = null;
            tamanio = 0;
            nombre = null;

        }
        protected Publicacion(string foto, string tipoAnimal, string raza, float tamanio, string nombre)
        {
            this.foto = foto;
            this.tipoAnimal = tipoAnimal;
            this.raza = raza;
            this.tamanio = tamanio;
            this.nombre = nombre;
        }
    }
}