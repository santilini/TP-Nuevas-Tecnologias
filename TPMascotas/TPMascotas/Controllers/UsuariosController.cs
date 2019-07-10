using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using TPMascotas.ViewModels;
using System.Threading.Tasks;

namespace TPMascotas.Models
{
    public class UsuariosController : Controller
    {
        // GET: Usuarios
        private PerdidoContext _context;

        public UsuariosController()
        {
            _context = new PerdidoContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        [HttpGet]
        public ActionResult Login()
        {
            LoginViewModel login = new LoginViewModel();
            return View(login);
        }
        /* Modificado por otra forma de hacer lo mismo
         * [HttpPost]
          public ActionResult Login(LoginViewModel login)
          {
              if (ModelState.IsValid)
              {
                  var userManager = HttpContext.GetOwinContext().GetUserManager<AppUserManager>();
                  var authManager = HttpContext.GetOwinContext().Authentication;

                  AppUser user = userManager.Find(login.Email, login.Password);
                  if (user != null)
                  {
                      var ident = userManager.CreateIdentity(user,
                          DefaultAuthenticationTypes.ApplicationCookie);
                      //use the instance that has been created. 
                      authManager.SignIn(
                          new AuthenticationProperties { IsPersistent = false }, ident);
                      return Redirect(login.ReturnUrl ?? Url.Action("Index", "Home"));
                  }
              }
              ModelState.AddModelError("", "Invalid username or password");
              return View(login);
          }
          */
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> Login(LoginViewModel login)
        {
            if (ModelState.IsValid)
            {
                if (login.login())
                {
                    Session["UserName"] = login.UserName;
                }
                return View();
            } else
            {
                return View("Index");
            }
        }
        public ActionResult Registrar()
        {
            AppUser Login = new AppUser();
            return View(Login);
            

        }
        [HttpPost]
        public ActionResult Registrar(AppUser usuario)
        {
            var userManager = HttpContext.GetOwinContext().GetUserManager<AppUserManager>();

            AppUser user = userManager.FindByName(usuario.UserName);
            if (user != null)
            {
                return HttpNotFound();
            }
            else
            {
                _context.Users.Add(usuario);
                _context.SaveChanges();
                return RedirectToRoute("Index", "Home");

            }
        }

    }
}