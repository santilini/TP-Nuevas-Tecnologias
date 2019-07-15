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
      
        [Required]
        [DataType(DataType.Text)]
        public string UserName { get; set; }
        [EmailAddress]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Ingrese Email correcto.")]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "Email invalido.")]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Ingerese su Password")]
        public string Password { get; set; }
        [Required]
        [Display(Name = "Nombre de contacto")]
        [DataType(DataType.Text)]
        public string NombreCompleto { get; set; }
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Ingrese numero de fijo/celular")]
        public string NumeroCelular { get; set; }
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "De que tipo es su vivienda? Casa, Departamento? Grande, chica?")]
        public String Vivienda { get; set; }
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Ingrese su localidad/barrio")]
        public string Localidad { get; set; }

        public Usuario(string mail, string contrasenia, string nombreCompleto, string numeroCelular, string viveEnCasaODepto, string localidad)
        {
            
            Email = mail;
            Password = contrasenia;
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