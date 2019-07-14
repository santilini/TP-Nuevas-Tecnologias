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

     //   [HttpGet]
      //  public ActionResult Login(LoginViewModel login)
      //  {
       //     if (login == null)
       //     {
        //        login = new LoginViewModel();
         //   }
           // return View(login);
        //}
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
       // [HttpPost]
        public  ActionResult Login(LoginViewModel login)
        {
            if (ModelState.IsValid)
            {
                if (login == null && login.UserName == null)
                {
                    ViewBag.Message = "Ingrese sus datos";
                    return View(login);

                }
                if (login.login())
                {
                    var userManager = HttpContext.GetOwinContext().GetUserManager<AppUserManager>();

                    AppUser user = userManager.FindByName(login.UserName);
                    if (user == null)
                    {
                        ViewBag.Message = "Por alguna extrania razon no se encontro tu usuario, pruebe nueva,emte";
                        return View(login);
                    }
                    Session["UserName"] = login.UserName;
                    Session["UserID"] = user.Id;

                    if (login.ReturnUrl == null)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    return Redirect(login.ReturnUrl);

                }
                else
                {
                    ViewBag.Message = "Login invalido, reintentar";
                    return View(login);
                }
                
            }
            else
            {
                return View(login);
            }
               
           
        }
        public ActionResult Registrar()
        {
            AppUser Login = new AppUser();
            ViewBag.Message = "Por favor registrese";
            return View(Login);
            

        }
        [HttpPost]
        public ActionResult Registrar(AppUser usuario)
        {
            var userManager = HttpContext.GetOwinContext().GetUserManager<AppUserManager>();

            AppUser user = userManager.FindByName(usuario.UserName);
           
            if (user != null && userManager.FindByEmail(usuario.Email) != null)
            {
                ViewBag.Message = "El nombre de usuario y/o el mail ya estan en uso";
                return View(usuario);
            }
            else
            {
               
                _context.Users.Add(usuario);
                _context.SaveChanges();
                return RedirectToAction("Index", "Home");

            }
        }

        public ActionResult Perfil()
        {
            string UserID =(string) Session["UserID"];
            if (UserID == null)
                return HttpNotFound();
            List < Perdido >perdidos  = _context.Perdidos.ToList();
            if (perdidos.Count() > 0)
                 perdidos = perdidos.FindAll(m => m.UsuarioID.Equals(UserID) && m.Visible);
            List<Adoptado> adoptados = _context.Adoptados.ToList().FindAll(m => m.UsuarioID.Equals(UserID) && m.Visible);
            List<Encontrado> encontrados = _context.Encontrados.ToList().FindAll(m => m.UsuarioID.Equals(UserID) && m.Visible);
            List<Notificacion> notifs = _context.Notificaciones.ToList().FindAll(m => m.UsuarioPublicacionID.Equals(UserID) && m.Visible);
            PerfilViewModel perfil = new PerfilViewModel(adoptados, perdidos, encontrados, notifs);

            return View(perfil);
        }
      public ActionResult NotifBorrar(int id)
        {
            string UserID = (string)Session["UserID"];
            Notificacion notif = _context.Notificaciones.ToList().Find(m => m.Id == id && m.UsuarioPublicacionID.Equals(UserID)&& m.Visible);
            if (notif == null)
                return HttpNotFound();
            notif.Visible = false;
            _context.SaveChanges();
            return Redirect("/Usuarios/Perfil");
        }

    }
}