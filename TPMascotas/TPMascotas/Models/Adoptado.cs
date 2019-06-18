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
        [Key]
        public int AdoptadoID { get; set; }

        public int Edad { get; set; }
       // private List<String> enfermedades;
        public int NivelSociabilidad { get; set; }
        public Boolean SociablAanimal { get; set; }
        public String Sexo { get; set; }
       

        public Adoptado(string tipo, string nombre, string raza, int edad, float tamanio, int nivelSociabilidad, bool sociableanimal, string sexo, string foto) : base (foto, tipo, raza, tamanio, nombre)
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