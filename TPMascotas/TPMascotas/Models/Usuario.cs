using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TPMascotas.Models
{
    public class Usuario
    {
        [Key]
        public int UsuarioID { get; set; }
        public string Mail { get; set; }
        public string Contrasenia { get; set; }
        public string NombreCompleto { get; set; }
        public string NumeroCelular { get; set; }
        public Boolean ViveEnCasaODepto { get; set; }
        public string Localidad { get; set; }

        public Usuario(string mail, string contrasenia, string nombreCompleto, string numeroCelular, bool viveEnCasaODepto, string localidad)
        {
            Mail = mail;
            Contrasenia = contrasenia;
            NombreCompleto = nombreCompleto;
            NumeroCelular = numeroCelular;
            ViveEnCasaODepto = viveEnCasaODepto;
            Localidad = localidad;
        }
        public Usuario()
        {

        }
    }
}