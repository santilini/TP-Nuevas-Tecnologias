using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TPMascotas.ViewModels;

namespace TPMascotas.Models
{
    public class AdoptadosController : Controller
    {
        //    List<Adoptado> porAhora = new List<Adoptado>();
        // GET: Adoptados
        private PerdidoContext _context;

        public AdoptadosController()
        {
            _context = new PerdidoContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        public ActionResult Index(string tipoDefiltro, string contenido, int page = 1)
        {
            var adoptados = _context.Adoptados.ToList();



            AdoptadoViewModel p = new AdoptadoViewModel(adoptados);
            ViewBag.Message = "Publicaciones de animales en adopcion.";
            if (adoptados != null)
                return View(p);
            else return Content("no tenemos publicaciones de mascotas, por favor pruebe el proximo mes");


          //  return View();
        }

        [HttpGet]
        public ActionResult Add()
        {
            var id = Session["UserID"];
            if (id == null)
            {
                return GoLogin("/Adoptados/Add");
            }
           ViewBag.Message = "Publica el animal en adopcion.";
            Adoptado adoptado = new Adoptado
            {
                UsuarioID = (string)id
            };
            
            return View("Add", adoptado);
        }
        [HttpPost]
        public ActionResult Add(Adoptado adoptado)
        {
            
           _context.Adoptados.Add(adoptado);
           _context.SaveChanges();
           return RedirectToAction("Index", "Adoptados");
            
        }
        public ActionResult Adoptado(int id)
        {
            var Adoptado = _context.Adoptados.SingleOrDefault(l => l.Id == id);
            if (Adoptado == null)
                return HttpNotFound();
            string UserID = (string)Session["UserID"];
            if (Adoptado.UsuarioID.Equals(UserID))
            {
                return Redirect("/Adoptados/Edit/" + id);
            }
            else return View(Adoptado);
        }
        public ActionResult Edit(int id)
        {
            var Adoptado = _context.Adoptados.SingleOrDefault(l => l.Id == id);
            string UserID = (string)Session["UserID"];

            if (Adoptado == null || !Adoptado.UsuarioID.Equals(UserID))
                return HttpNotFound();

            return View(Adoptado);
        }
        [HttpPost]
        public ActionResult Edit( Adoptado adoptado)
        {
            var Adop = _context.Adoptados.Single(l => l.Id == adoptado.Id);
            if (Adop == null)
                return HttpNotFound();
            Adop.Desc = adoptado.Desc;
            Adop.Edad = adoptado.Edad;
            Adop.Foto = adoptado.Foto;
            Adop.Genero = adoptado.Genero;
            Adop.NivelSociabilidad = adoptado.NivelSociabilidad;
            Adop.Nombre = adoptado.Nombre;
            Adop.Raza = adoptado.Raza;
            Adop.SociablAanimal = adoptado.SociablAanimal;
            Adop.Tamanio = adoptado.Tamanio;
            _context.SaveChanges();
            return RedirectToAction("Index", "Adoptados");
        }
        public ActionResult Adoptar(int id)
        {
            string UserId = (string)Session["UserID"];
            var Adoptado = _context.Adoptados.SingleOrDefault(l => l.Id == id);
            if (UserId == null)
            {
                return GoLogin("/Adoptados/Adoptar/" + id);
            }
            Notificacion adoptando = _context.Notificaciones.ToList().Find(l => l.UsuarioInteresadoID.Equals(UserId) && l.UsuarioPublicacionID.Equals(Adoptado.UsuarioID) &&l.Visible && l.PubID == id);
            if (adoptando != null)
                return Content("Ya has creado una notificacion para esta publicacion, espera a ser contactado");
            adoptando = new Notificacion(id, "a", Adoptado.UsuarioID, UserId);
            _context.Notificaciones.Add(adoptando);
            _context.SaveChanges();
            return Content("El usuario ha sido notificado de tu interes por " + Adoptado.Nombre + ".");
        }
        public ActionResult Remove(int id)
        {
            var Adoptado = _context.Adoptados.SingleOrDefault(l => l.Id == id);
            if (Adoptado == null)
                return HttpNotFound();
            Adoptado.Visible = false;
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