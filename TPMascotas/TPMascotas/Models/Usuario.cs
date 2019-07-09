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
        public int Id { get; set; }
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Mail { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Contrasenia { get; set; }
        [Required]
        [DataType(DataType.Text)]
        public string NombreCompleto { get; set; }
        [Required]
        [DataType(DataType.Text)]
        public string NumeroCelular { get; set; }
        [Required]
        [DataType(DataType.Text)]
        public String Vivienda { get; set; }
        [Required]
        [DataType(DataType.Text)]
        public string Localidad { get; set; }

        public Usuario(string mail, string contrasenia, string nombreCompleto, string numeroCelular, string viveEnCasaODepto, string localidad)
        {
            Mail = mail;
            Contrasenia = contrasenia;
            NombreCompleto = nombreCompleto;
            NumeroCelular = numeroCelular;
            Vivienda = viveEnCasaODepto;
            Localidad = localidad;
        }
        public Usuario()
        {

        }
    }
}