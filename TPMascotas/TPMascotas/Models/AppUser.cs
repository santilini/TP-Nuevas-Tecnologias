using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TPMascotas.Models
{
    public class AppUser : IdentityUser
    {
        //add your custom properties which have not included in IdentityUser before
        public string MyExtraProperty { get; set; }
       
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

      
        public AppUser() : base()
        {

        }
    }
}