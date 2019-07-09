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
       
           ViewBag.Message = "Publica el animal en adopcion.";
            return View("Add",new Adoptado());
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
            else return View(Adoptado);
        }
    }
}