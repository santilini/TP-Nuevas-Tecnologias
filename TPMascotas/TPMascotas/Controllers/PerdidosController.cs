using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TPMascotas.ViewModels;

namespace TPMascotas.Models
{
    public class PerdidosController : Controller
    {
        private PerdidoContext _context;

        public PerdidosController()
        {
            _context = new PerdidoContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        public ActionResult Index(string tipoDefiltro, string contenido, int page = 1)
        {
            var perdidos = _context.Perdidos.ToList();


            PerdidoViewModel p = new PerdidoViewModel(perdidos);
            ViewBag.Message = "Publicaciones de animales perdidos.";
            if (perdidos != null)
                return View(p);
            else return Content("no tenemos publicaciones de animales perdidos, por favor pruebe el proximo mes");
        }

        
       [HttpGet]
        public ActionResult Add()
        {
            var id = Session["UserID"];
            if (id == null)
            {
                return GoLogin("/Perdidos/Add");
            }
            ViewBag.Message = "Publica el animal perdido.";
            Perdido perdido = new Perdido
            {
                UsuarioID = (string)id
            };

            return View("Add", perdido);
        }
        [HttpPost]
        public ActionResult Add(Perdido perdido)
        {

            _context.Perdidos.Add(perdido);
            _context.SaveChanges();
            return RedirectToAction("Index", "Perdidos");

        }
        public ActionResult Perdido(int id)
        {
            var Perdido = _context.Perdidos.SingleOrDefault(l => l.Id == id && l.Visible);
            if (Perdido == null)
                return HttpNotFound();
            string UserID = (string)Session["UserID"];
            if (Perdido.UsuarioID.Equals(UserID))
            {
                return Redirect("/Perdidos/Edit/" + id);
            }
            else return View(Perdido);
        }
        public ActionResult Edit(int id)
        {
            var Perdido = _context.Perdidos.SingleOrDefault(l => l.Id == id && l.Visible);
            string UserID = (string)Session["UserID"];

            if (Perdido == null || !Perdido.UsuarioID.Equals(UserID))
                return HttpNotFound();

            return View(Perdido);
        }
        [HttpPost]
        public ActionResult Edit(Perdido perdido)
        {
            var Adop = _context.Perdidos.Single(l => l.Id == perdido.Id);
            if (Adop == null)
                return HttpNotFound();
            Adop.Desc = perdido.Desc;
            
            Adop.Foto = perdido.Foto;
            Adop.Genero = perdido.Genero;
            
            Adop.Nombre = perdido.Nombre;
            Adop.Raza = perdido.Raza;
            
            Adop.Tamanio = perdido.Tamanio;
            Adop.Zona = perdido.Zona;
            Adop.Recompensa = perdido.Recompensa;
            _context.SaveChanges();
            return RedirectToAction("Index", "Perdidos");
        }
        public ActionResult Perdidos(int id)
        {
            string UserId = (string)Session["UserID"];
            var Perdido = _context.Perdidos.SingleOrDefault(l => l.Id == id);
            if (UserId == null)
            {
                return GoLogin("/Perdidos/Perder/" + id);
            }
            Notificacion perdiendo = _context.Notificaciones.ToList().Find(l => l.UsuarioInteresadoID.Equals(UserId) && l.UsuarioPublicacionID.Equals(Perdido.UsuarioID) && l.Visible && l.PubID == id);
            if (perdiendo != null)
                return Content("Ya has creado una notificacion para esta publicacion, espera a ser contactado");
            perdiendo = new Notificacion(id, "a", Perdido.UsuarioID, UserId);
            _context.Notificaciones.Add(perdiendo);
            _context.SaveChanges();
            return Content("El usuario ha sido notificado de tu interes por " + Perdido.Nombre + ".");
        }
        public ActionResult Remove(int id)
        {
            string UserId = (string)Session["UserID"];
            if (UserId == null)
                return HttpNotFound();
            var Perdido = _context.Perdidos.SingleOrDefault(l => l.Id == id);
            if (Perdido == null)
                return HttpNotFound();
            Perdido.Visible = false;
            _context.SaveChanges();
            return Redirect("/Usuarios/Perfil");
        }
        public ActionResult GoLogin(string direccion)
        {
            LoginViewModel login = new LoginViewModel();
            login.ReturnUrl = direccion;
            return RedirectToAction("Login", "Usuarios", login);
        }
    }
}