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
            ViewBag.Message = "Publica el animal perdido.";
            return View("Add",new Perdido());
        }
        [HttpPost]
        public ActionResult Add(Perdido perdido)
        {
            _context.Perdidos.Add(perdido);
            _context.SaveChanges();
            return RedirectToAction("Index", "Perdidos");
        }
        public ActionResult Perdido (int id)
        {
            var Perdido = _context.Perdidos.SingleOrDefault(l => l.Id == id);
            if (Perdido == null)
                return HttpNotFound();
            else return View(Perdido);
        }
    }
}