using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TPMascotas.Models;
using TPMascotas.ViewModels;

namespace TPMascotas.Controllers
{

 
    public class HomeController : Controller
    {
        private PerdidoContext _context;

        public HomeController()
        {
            _context = new PerdidoContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        public ActionResult Index()
        {
           FullViewModel viewmodel = new FullViewModel(_context.Adoptados.ToList(), _context.Encontrados.ToList(), _context.Perdidos.ToList());

            return View(viewmodel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Perdidos()
        {
            ViewBag.Message = "Publicaciones de animales perdidos";
            return View();
        }
 
        public ActionResult Encontrados()
        {
            ViewBag.Message = "Publicaciones de animales encontrados";
            return View();
        }
        public ActionResult Adopcion()
        {
            ViewBag.Message = "Publicaciones de animales en adopcion";
            return View();
        }
    }
}