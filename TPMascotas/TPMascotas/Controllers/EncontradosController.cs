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
            ViewBag.Message = "Publica el animal encontrado.";
            return View("Add", new Encontrado());
        }
        [HttpPost]
        public ActionResult Add(Encontrado encontrado)
        {
            _context.Encontrados.Add(encontrado);
            _context.SaveChanges();
            // ViewBag.Message = "Publica el animal encontrado " + tipo + " " + sexo + " " + raza + ". " + desc + ".";
            return RedirectToAction("Index", "Encontrados");
        }
    }
}