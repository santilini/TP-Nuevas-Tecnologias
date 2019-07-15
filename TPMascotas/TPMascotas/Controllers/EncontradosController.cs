using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TPMascotas.ViewModels;

namespace TPMascotas.Models
{
    public class EncontradosController : Controller
    {
        private PerdidoContext _context;

        public EncontradosController()
        {
            _context = new PerdidoContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Encontrados
        public ActionResult Index(string tipoDefiltro, string contenido, int page = 1)
        {
            var encontrados = _context.Encontrados.ToList();
           
       
            EncontradoViewModel p = new EncontradoViewModel(encontrados);
            ViewBag.Message = "Publicaciones de animales encontrados sin hogar.";
            if (encontrados != null)
                return View(p);
            else return Content("no tenemos publicaciones de mascotas, por favor pruebe el proximo mes");

        }

        [HttpGet]
        public ActionResult Add()
        {
            var id = Session["UserID"];
            if (id == null)
            {
                return GoLogin("/Encontrados/Add");
            }
            ViewBag.Message = "Publica el animal encontrado.";
            Encontrado encontrado = new Encontrado
            {
                UsuarioID = (string)id
            };

            return View("Add", encontrado);
        }
        [HttpPost]
        public ActionResult Add(Encontrado encontrado)
        {
            _context.Encontrados.Add(encontrado);
            _context.SaveChanges();
            // ViewBag.Message = "Publica el animal encontrado " + tipo + " " + sexo + " " + raza + ". " + desc + ".";
            return RedirectToAction("Index", "Encontrados");
        }
        public ActionResult Encontrado(int id)
        {
            var Encontrado = _context.Encontrados.SingleOrDefault(l => l.Id == id && l.Visible);
            if (Encontrado == null)
                return HttpNotFound();
            string UserID = (string)Session["UserID"];
            if (Encontrado.UsuarioID.Equals(UserID))
            {
                return Redirect("/Encontrados/Edit/" + id);
            }
            else return View(Encontrado);
        }
        public ActionResult Edit(int id)
        {
            var Encontrado = _context.Encontrados.SingleOrDefault(l => l.Id == id);
            string UserID = (string)Session["UserID"];

            if (Encontrado == null || !Encontrado.UsuarioID.Equals(UserID))
                return HttpNotFound();

            return View(Encontrado);
        }
        [HttpPost]
        public ActionResult Edit(Encontrado encontrado)
        {
            var Adop = _context.Encontrados.Single(l => l.Id == encontrado.Id);
            if (Adop == null)
                return HttpNotFound();
            Adop.Desc = encontrado.Desc;
            Adop.Foto = encontrado.Foto;
            Adop.Genero = encontrado.Genero;
            Adop.Localidad = encontrado.Localidad;
            Adop.Nombre = encontrado.Nombre;
            Adop.Raza = encontrado.Raza;
            Adop.Tamanio = encontrado.Tamanio;
            Adop.TipoAnimal = encontrado.TipoAnimal;
            _context.SaveChanges();
            return RedirectToAction("Index", "Encontrados");
        }
        public ActionResult Encontrar(int id)
        {
            string UserId = (string)Session["UserID"];
            var Encontrado = _context.Encontrados.SingleOrDefault(l => l.Id == id);
            if (UserId == null)
            {
                return GoLogin("/Encontrados/Encontrar/" + id);
            }
            Notificacion encontrando = _context.Notificaciones.ToList().Find(l => l.UsuarioInteresadoID.Equals(UserId) && l.UsuarioPublicacionID.Equals(Encontrado.UsuarioID) && l.Visible && l.PubID == id);
            if (encontrando != null)
                return Content("Ya has creado una notificacion para esta publicacion, espera a ser contactado");
            encontrando = new Notificacion(id, "a",Encontrado.UsuarioID, UserId);
            _context.Notificaciones.Add(encontrando);
            _context.SaveChanges();
            return Content("El usuario ha sido notificado de tu interes por " + Encontrado.Nombre + ".");
        }
        public ActionResult Remove(int id)
        {
            string UserId = (string)Session["UserID"];
            if (UserId == null)
                return HttpNotFound();
            var Encontrado = _context.Encontrados.SingleOrDefault(l => l.Id == id);
            if (Encontrado == null)
                return HttpNotFound();
            Encontrado.Visible = false;
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

