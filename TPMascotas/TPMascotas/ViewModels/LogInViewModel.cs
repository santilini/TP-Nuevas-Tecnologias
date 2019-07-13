using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TPMascotas.Models;

namespace TPMascotas.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
        public string ReturnUrl { get; set; }
        public string UserName { get; set; }

        PerdidoContext User = new PerdidoContext();
        public bool login()
        {
            var query = from u in User.Users
                        where u.Email == Email && u.PasswordHash == Password
                        select u;
            if (query.Count() > 0)
            {
                var query2 = from u in User.Users where u.Email == Email select u;
                var datos = query2.ToList();
                foreach (var Data in datos)
                {
                    UserName = Data.UserName;
                }
                return true;
            } else
            {
                return false;
            }
        }
       
      
    }
}