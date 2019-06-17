using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TPMascotas.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
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