using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TPMascotas.Models
{
    public class AdoptadosController : Controller
    {
        List<Adoptado> porAhora = new List<Adoptado>();
        // GET: Adoptados
        public ActionResult Index()
        {
            return View(porAhora);
        }

        [HttpGet]
        public ActionResult Add()
        {
            ViewBag.Message = "Publica el animal encontrado.";
            return View();
        }
        [HttpPost]
        public ActionResult Add(string tipo, string nombre, string raza, int edad, float tamaño, int nivelSociabilidad, bool sociableanimal, string sexo)
        {
            Adoptado animal = new Adoptado(tipo, nombre, raza, edad, tamaño, nivelSociabilidad, sociableanimal, sexo);
            porAhora.Add(animal);
            ViewBag.Message = "Publica el animal encontrado " + tipo + " " + sexo + " " + raza + ". "  + ".";
            return View();
        }
    }
}