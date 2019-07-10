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