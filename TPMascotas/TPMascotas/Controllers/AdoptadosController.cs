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
        public ActionResult Index()
        {
            var adoptados = _context.Adoptados.ToList();
            AdoptadoPruebaViewModel p = new AdoptadoPruebaViewModel(adoptados);
            if (adoptados != null)
                return View(p);
            else return Content("no tenemos publicaciones de mascotas, por favor pruebe el proximo mes");


          //  return View();
        }

        [HttpGet]
        public ActionResult Add()
        {
       
           // ViewBag.Message = "Publica el animal encontrado.";
            return View();
        }
        [HttpPost]
        public ActionResult Add(string desc, string tipo, string nombre, string raza, int edad, float tamaño, int nivelSociabilidad, bool sociableanimal, string sexo, string foto)
        {
            Adoptado a = new Adoptado(tipo, nombre, raza, edad, tamaño, nivelSociabilidad, sociableanimal, sexo, foto, desc);
            _context.Adoptados.Add(a);
          //  Adoptado animal = new Adoptado(tipo, nombre, raza, edad, tamaño, nivelSociabilidad, sociableanimal, sexo);
            //porAhora.Add(animal);
            ViewBag.Message = "Publica el animal encontrado " + tipo + " " + sexo + " " + raza + ". "  + ".";
            return View();
        }
    }
}