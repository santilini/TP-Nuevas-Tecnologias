﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TPMascotas.Models
{
    public class Perdido : Publicacion
    {
        
        public String Descripcion { get; set; }
        [Display(Name = "Quiere agregar una recompenza por encontrar a su mascota?")]
        public float Recompensa { get; set; }
        [Display(Name = "Barrio/Localidad/Ciudad donde fue extraviada?")]
        public String Zona { get; set; }

        public Perdido(string descripcion, float recompensa, string zona, string foto, string tipoAnimal, string raza, string tamanio, string nombre, string desc, string genero) : base(foto, tipoAnimal, raza, tamanio, nombre, desc, genero)
        {
            
            this.Descripcion = descripcion;
            this.Recompensa = recompensa;
            this.Zona = zona;
        }
        public Perdido() : base()
        {

        }
    }
}