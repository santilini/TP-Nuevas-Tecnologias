using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TPMascotas.Models
{
    public class Perdido : Publicacion
    {
        [Key]
        public int PerdidoID { get; set; }
        public String descripcion { get; set; }
        public float recompensa { get; set; }
        public String zona { get; set; }

        public Perdido(string descripcion, float recompensa, string zona, string foto, string tipoAnimal, string raza, float tamanio, string nombre) : base(foto, tipoAnimal, raza, tamanio, nombre)
        {
            
            this.descripcion = descripcion;
            this.recompensa = recompensa;
            this.zona = zona;
        }
        public Perdido() : base()
        {

        }
    }
}