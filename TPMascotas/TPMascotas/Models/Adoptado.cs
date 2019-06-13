using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TPMascotas.Models
{
    public class Adoptado
    {
        private String tipo { get; set; }
        private String nombre { get; set; }
        private String raza { get; set; }
        private int edad { get; set; }
        private float tamaño { get; set; }
       // private List<String> enfermedades;
        private int nivelSociabilidad { get; set; }
        private Boolean sociableanimal { get; set; }
        private String sexo { get; set; }

        public Adoptado(string tipo, string nombre, string raza, int edad, float tamaño, int nivelSociabilidad, bool sociableanimal, string sexo)
        {
            this.tipo = tipo;
            this.nombre = nombre;
            this.raza = raza;
            this.edad = edad;
            this.tamaño = tamaño;
            this.nivelSociabilidad = nivelSociabilidad;
            this.sociableanimal = sociableanimal;
            this.sexo = sexo;
        }
    }

        

    
    
}