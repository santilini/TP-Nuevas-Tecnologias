using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TPMascotas.Models
{
    public class EncontradosController : Controller
    {
        // GET: Encontrados
        public ActionResult Index()
        {
            return View();
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
            ViewBag.Message = "Publica el animal encontrado " + tipo + " " + sexo + " " + raza + ". " + desc + ".";
            return View();
        }
    }
}