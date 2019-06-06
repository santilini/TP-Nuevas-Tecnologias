using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TPMascotas.Models
{
    public class PublicacionesController : Controller
    {
        // GET: Publicaciones
        public ActionResult Publicacion()
        {
            return View(new Publicacion());
        }
    }
}