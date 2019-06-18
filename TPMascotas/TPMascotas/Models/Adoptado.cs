using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TPMascotas.Models
{
    public class Adoptado : Publicacion
    {
      
        private int Edad { get; set; }
       // private List<String> enfermedades;
        private int NivelSociabilidad { get; set; }
        private Boolean Sociableanimal { get; set; }
        private String Sexo { get; set; }

        public Adoptado(string tipo, string nombre, string raza, int edad, float tamanio, int nivelSociabilidad, bool sociableanimal, string sexo, string foto) : base (foto, tipo, raza, tamanio, nombre)
        {
            this.Edad = edad;
            this.NivelSociabilidad = nivelSociabilidad;
            this.Sociableanimal = sociableanimal;
            this.Sexo = sexo;
        }
    }

        

    
    
}