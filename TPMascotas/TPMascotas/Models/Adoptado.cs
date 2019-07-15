using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TPMascotas.Models
{
    public class Adoptado : Publicacion
    {
        [Display(Name = "Edad de la mascota?")]
        public int Edad { get; set; }
        // private List<String> enfermedades;
        [Display(Name = "Como calificarias que se lleva con otra gente?")]
        public string NivelSociabilidad { get; set; }
        [Display(Name = "Y con otros animales?")]
        public string SociablAanimal { get; set; }
        public String Sexo { get; set; }
       

        public Adoptado(string tipo, string nombre, string raza, int edad, string tamanio, string nivelSociabilidad, string sociableanimal, string sexo, string foto, string desc) : base (foto, tipo, raza, tamanio, nombre, desc, sexo)
        {
            this.Edad = edad;
            this.NivelSociabilidad = nivelSociabilidad;
            this.SociablAanimal = sociableanimal;
            this.Sexo = sexo;
        }
        public Adoptado(): base()
        {

        }
    }
}