using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TPMascotas.Models
{
    public class PerdidosController : Controller
    {
        public Perdido p { get; set; }
        // GET: Perdidos
        public ActionResult Index()
        {
            return View(new Perdido("Ladra", 1000, "Palermo", "asdda", "Canario", "Siberiano", 100, "Firulais"));
        }

        [HttpGet]
        public ActionResult Add()
        {
            ViewBag.Message = "Publica el animal encontrado.";
            return View();
        }
        [HttpPost]
        public ActionResult Add(String tipo, String sexo, String raza, String desc)
        {
             p = new Perdido(desc, 1000, "palermo", "asdsd", tipo, raza, 14, "Firulais" );
            ViewBag.Message = "Publica el animal encontrado " + tipo + " " + sexo + " " + raza + ". " + desc + ".";
            return View();
        }
    }
}